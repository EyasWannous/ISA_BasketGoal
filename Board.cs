using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISA_BasketGoal;

internal class Board
{
    public Position BasketPosition;
    public List<Position> BallPosition = new();
    public List<Position>? FixedWalls;
    public Position? Coin;
    public readonly int ColumnNumbers;
    public readonly int RowNumbers;
    public char[,] PlayBoard;

    public Board(
        int columnNumbers,
        int rowNumbers,
        char[,] playBoard)
    {
        BasketPosition = new(-1, -1);
        BallPosition[0] = new(-1, -1);
        ColumnNumbers = columnNumbers;
        RowNumbers = rowNumbers;
        PlayBoard = playBoard;
    }

    public Board(
        Position basketPosition,
        List<Position> ballPosition,
        List<Position>? fixedWalls,
        Position? coin,
        int columnNumbers,
        int rowNumbers,
        char[,] playBoard)
    {
        BasketPosition = basketPosition;
        BallPosition = ballPosition;
        FixedWalls = fixedWalls;
        Coin = coin;
        ColumnNumbers = columnNumbers;
        RowNumbers = rowNumbers;
        PlayBoard = playBoard;
    }

    public Board(Board board)
    {
        ColumnNumbers = board.ColumnNumbers;
        RowNumbers = board.RowNumbers;

        BasketPosition = board.BasketPosition.Copy();
        BallPosition = board.BallPosition.ToList();

        PlayBoard = new char[board.RowNumbers, board.ColumnNumbers];
        for (int i = 0; i < RowNumbers; i++)
        {
            for (int j = 0; j < ColumnNumbers; j++)
            {
                PlayBoard[i, j] = board.PlayBoard[i, j];
            }
        }

        if (board.FixedWalls is not null) FixedWalls = board.FixedWalls.ToList();
        if (board.Coin is not null) Coin = board.Coin.Copy();
    }

    public char this[int indexOne, int indexTwo]
    {
        get { return PlayBoard[indexOne, indexTwo]; }

        set { PlayBoard[indexOne, indexTwo] = value; }
    }

    public bool Move(char move)
    {
        return move switch
        {
            'W' or 'w' => MoveUp(),
            'S' or 's' => MoveDown(),
            'D' or 'd' => MoveRight(),
            'A' or 'a' => MoveLeft(),
            'M' or 'm' => CheckMoves().Item1,
            'H' or 'h' => CheckMovesUsingHashSet().Item1,
            'P' or 'p' => PrintPossiableMoves(),
            _ => false,
        };
    }

    protected bool MoveUp()
    {
        for (int i = 0; i < RowNumbers; i++)
        {
            for (int j = 0; j < ColumnNumbers; j++)
            {
                if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves._upMove);

                if (PlayBoard[i, j] == 'V') obstacle = Eat(obstacle);

                var temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[obstacle.Row - Moves._upMove.Row, j] = temp;

                UpdateMovedElement(temp, new(i, j), new(obstacle.Row - Moves._upMove.Row, j));
            }
        }

        return true;
    }

    protected bool MoveDown()
    {
        for (int i = RowNumbers - 1; i >= 0; i--)
        {
            for (int j = 0; j < ColumnNumbers; j++)
            {
                if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves._downMove);

                if (!CheckCollisionWithSides(obstacle)
                    && PlayBoard[obstacle.Row, obstacle.Column] == 'V')
                {
                    Eat(new(i, j));
                    continue;
                }

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[obstacle.Row - Moves._downMove.Row, j] = temp;

                UpdateMovedElement(temp, new(i, j), new(obstacle.Row - Moves._downMove.Row, j));
            }
        }

        return true;
    }

    protected bool MoveLeft()
    {
        for (int j = 0; j < ColumnNumbers; j++)
        {
            for (int i = 0; i < RowNumbers; i++)
            {
                if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves._leftMove);

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[i, obstacle.Column - Moves._leftMove.Column] = temp;

                UpdateMovedElement(temp, new(i, j), new(i, obstacle.Column - Moves._leftMove.Column));
            }
        }

        return true;
    }

    protected bool MoveRight()
    {
        for (int j = ColumnNumbers - 1; j >= 0; j--)
        {
            for (int i = 0; i < RowNumbers; i++)
            {
                if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves._rightMove);

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[i, obstacle.Column - Moves._rightMove.Column] = temp;

                UpdateMovedElement(temp, new(i, j), new(i, obstacle.Column - Moves._rightMove.Column));

            }
        }

        return true;
    }

    protected (bool, string) CheckMoves()
    {
        if (this.IsFinal()) return (false, "");

        string temp = "\n { ";

        Board board = new(this);

        board.MoveUp();

        if (!this.Equals(board)) temp += " W,";

        board = new(this);
        board.MoveDown();

        if (!this.Equals(board)) temp += " S,";

        board = new(this);
        board.MoveRight();

        if (!this.Equals(board)) temp += " D,";

        board = new(this);
        board.MoveLeft();

        if (!this.Equals(board)) temp += " A,";

        temp += " } \n";
        // Console.WriteLine(temp);

        return (true, temp);
    }

    protected (bool, string) CheckMovesUsingHashSet()
    {
        bool thereIsMove = false;

        if (this.IsFinal()) return (thereIsMove, "");

        HashSet<Board> toCheck = new() { this };

        string temp = "\n { ";

        Board board = new(this);
        board.MoveUp();
        toCheck.Add(board);

        if (toCheck.Count == 2)
        {
            temp += " W,";
            thereIsMove = true;
            toCheck.Remove(board);
        }

        board = new(this);
        board.MoveDown();
        toCheck.Add(board);

        if (toCheck.Count == 2)
        {
            temp += " S,";
            thereIsMove = true;
            toCheck.Remove(board);
        }

        board = new(this);
        board.MoveRight();
        toCheck.Add(board);


        if (toCheck.Count == 2)
        {
            temp += " D,";
            thereIsMove = true;
            toCheck.Remove(board);
        }

        board = new(this);
        board.MoveLeft();
        toCheck.Add(board);

        if (toCheck.Count == 2)
        {
            temp += " A,";
            thereIsMove = true;
        }

        temp += " } \n";
        // Console.WriteLine(temp);

        return (thereIsMove, temp);
    }

    protected bool PrintPossiableMoves()
    {
        if (this.IsFinal()) return false;

        bool thereIsMove;
        string temp;

        (thereIsMove, temp) = CheckMovesUsingHashSet();

        if (!thereIsMove) return false;

        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == 'W')
            {
                Console.WriteLine("Move Up Using 'W' :\n");
                Board board = new(this);
                board.MoveUp();
                Console.WriteLine(board);
            }

            else if (temp[i] == 'S')
            {
                Console.WriteLine("Move Down Using 'S' :\n");
                Board board = new(this);
                board.MoveDown();
                Console.WriteLine(board);
            }

            else if (temp[i] == 'D')
            {
                Console.WriteLine("Move Right Using 'D' :\n");
                Board board = new(this);
                board.MoveRight();
                Console.WriteLine(board);
            }

            else if (temp[i] == 'A')
            {
                Console.WriteLine("Move Lefts Using 'A' :\n");
                Board board = new(this);
                board.MoveLeft();
                Console.WriteLine(board);
            }
        }

        // 5 8 11 14

        return true;
    }

    protected bool CheckCollisionWithSides(Position element)
    {
        // There is A Collision
        if (element.Row < 0 || element.Column < 0
        || element.Row >= RowNumbers
        || element.Column >= ColumnNumbers) return true;

        return false;
    }

    protected Position GetFirstObstacleInRoad(Position element, Position move)
    {
        Position newPlace = element + move;
        //Position? ObstacleInRoad;

        while (!CheckCollisionWithSides(newPlace))
        {
            if (PlayBoard[newPlace.Row, newPlace.Column] == ' ')
            {
                newPlace += move;
                continue;
            }

            //ObstacleInRoad = GetObstacleInCollection(newPlace, BasketPosition);
            //if (ObstacleInRoad is not null) return ObstacleInRoad;

            //ObstacleInRoad = GetObstacleInCollection(newPlace, BallPosition);
            //if (ObstacleInRoad is not null) return ObstacleInRoad;

            //if (FixedWalls is not null)
            //{
            //    ObstacleInRoad = GetObstacleInCollection(newPlace, FixedWalls);
            //    if (ObstacleInRoad is not null) return ObstacleInRoad;
            //}

            //if (Coins is not null)
            //{
            //    ObstacleInRoad = GetObstacleInCollection(newPlace, Coins);
            //    if (ObstacleInRoad is not null) return ObstacleInRoad;
            //}

            //newPlace += move;
            return newPlace;
        }

        return newPlace;
    }

    protected void UpdateMovedElement(char moved, Position oldP, Position newP)
    {
        if (moved == 'O')
        {
            BallPosition[BallPosition.BinarySearch(oldP)]
                = new(newP.Row, newP.Column);
        }

        else if (moved == 'V') BasketPosition = new(newP.Row, newP.Column);

        else if (Coin is not null && moved == '$') Coin = new(newP.Row, newP.Column);
    }

    protected Position Eat(Position obstacle)
    {
        if (CheckCollisionWithSides(obstacle)
            || PlayBoard[obstacle.Row, obstacle.Column] == 'X') return obstacle;

        if (Coin is not null && obstacle == Coin) Coin = null;

        else BallPosition.Remove(obstacle);

        PlayBoard[obstacle.Row, obstacle.Column] = ' ';

        return obstacle + Moves._upMove;
    }

    public bool IsFinal()
    {
        if (BallPosition.Count == 0) return true;

        return false;
    }

    public List<Board> MovePossiable()
    {
        List<Board> boards = new();

        if (this.IsFinal()) return boards;

        bool thereIsMove;
        string temp;

        (thereIsMove, temp) = CheckMoves();

        if (!thereIsMove) return boards;

        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == 'W')
            {
                Board board = new(this);
                board.MoveUp();
                boards.Add(board);
            }

            else if (temp[i] == 'S')
            {
                Board board = new(this);
                board.MoveDown();
                boards.Add(board);
            }

            else if (temp[i] == 'D')
            {
                Board board = new(this);
                board.MoveRight();
                boards.Add(board);
            }

            else if (temp[i] == 'A')
            {
                Board board = new(this);
                board.MoveLeft();
                boards.Add(board);
            }
        }

        return boards;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Board board) return false;

        if (RowNumbers != board.RowNumbers || ColumnNumbers != board.ColumnNumbers) return false;

        for (int i = 0; i < RowNumbers; i++)
        {
            for (int j = 0; j < ColumnNumbers; j++)
            {
                if (PlayBoard[i, j] != board.PlayBoard[i, j]) return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {

        unchecked
        {

            HashCode hash = new();
            hash.Add(RowNumbers);
            hash.Add(ColumnNumbers);
            hash.Add(BasketPosition);

            foreach (var ball in BallPosition)
            {
                hash.Add(ball);
            }
            if (FixedWalls is not null)
            {
                foreach (var wall in FixedWalls)
                {
                    hash.Add(wall);
                }
            }

            if (Coin is not null)
            {
                hash.Add(Coin);
            }

            for (int i = 0; i < RowNumbers; i++)
            {
                for (int j = 0; j < ColumnNumbers; j++)
                {
                    hash.Add(PlayBoard[i, j]);
                }
            }

            return hash.ToHashCode();

        }

    }

    public override string ToString()
    {
        string temp = "";
        for (int i = 0; i < RowNumbers; i++)
        {
            temp += " | ";
            for (int j = 0; j < ColumnNumbers; j++)
            {
                temp += PlayBoard[i, j];
                temp += " | ";
            }
            temp += "\n";
        }
        return temp;
    }

}