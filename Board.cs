using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
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
    public List<Position>? MovingWalls;

    public Board(
        Position basketPosition,
        List<Position> ballPosition,
        List<Position>? fixedWalls,
        Position? coin,
        int columnNumbers,
        int rowNumbers,
        char[,] playBoard,
        List<Position>? movingWalls)
    {
        BasketPosition = basketPosition;
        BallPosition = ballPosition;
        FixedWalls = fixedWalls;
        Coin = coin;
        ColumnNumbers = columnNumbers;
        RowNumbers = rowNumbers;
        PlayBoard = playBoard;
        MovingWalls = movingWalls;
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
        if (board.MovingWalls is not null) MovingWalls = board.MovingWalls.ToList();
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
            'M' or 'm' => CheckMoves(true).Item1,
            'P' or 'p' => PrintPossibleMoves(),
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

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves.Up);

                if (PlayBoard[i, j] == 'V') obstacle = Eat(obstacle);

                var temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[obstacle.Row - Moves.Up.Row, j] = temp;

                UpdateMovedElement(temp, new(i, j), new(obstacle.Row - Moves.Up.Row, j));
            }
        }

        return true;
    }

    protected bool MoveDown()
    {
        bool didEat = false;
        for (int i = RowNumbers - 1; i >= 0; i--)
        {
            for (int j = 0; j < ColumnNumbers; j++)
            {
                if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves.Down);

                if (PlayBoard[i, j] != '■' &&
                    !didEat && !CheckCollisionWithSides(obstacle)
                    && PlayBoard[obstacle.Row, obstacle.Column] == 'V')
                {
                    didEat = true;
                    Eat(new(i, j));
                    continue;
                }

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[obstacle.Row - Moves.Down.Row, j] = temp;

                UpdateMovedElement(temp, new(i, j), new(obstacle.Row - Moves.Down.Row, j));
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

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves.Left);

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[i, obstacle.Column - Moves.Left.Column] = temp;

                UpdateMovedElement(temp, new(i, j), new(i, obstacle.Column - Moves.Left.Column));
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

                Position obstacle = GetFirstObstacleInRoad(new(i, j), Moves.Right);

                char temp = PlayBoard[i, j];
                PlayBoard[i, j] = ' ';
                PlayBoard[i, obstacle.Column - Moves.Right.Column] = temp;

                UpdateMovedElement(temp, new(i, j), new(i, obstacle.Column - Moves.Right.Column));
            }
        }

        return true;
    }

    protected (bool, string) CheckMoves(bool print)
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

        if (print) Console.WriteLine(temp);

        return (true, temp);
    }

    protected bool PrintPossibleMoves()
    {
        if (this.IsFinal()) return false;

        bool thereIsMove;
        string temp;

        (thereIsMove, temp) = CheckMoves(false);

        if (!thereIsMove) return false;

        for (int i = 0; i < temp.Length; i++)
        {

            switch (temp[i])
            {
                case 'W':
                    Write.MoveUp();
                    Board Up = new(this);
                    Up.MoveUp();
                    Write.Board(Up);
                    break;

                case 'S':
                    Write.MoveDown();
                    Board Down = new(this);
                    Down.MoveDown();
                    Write.Board(Down);
                    break;

                case 'A':
                    Write.MoveLeft();
                    Board Left = new(this);
                    Left.MoveLeft();
                    Write.Board(Left);
                    break;

                case 'D':
                    Write.MoveRight();
                    Board Right = new(this);
                    Right.MoveRight();
                    Write.Board(Right);
                    break;
            }

        }

        return true;
    }

    protected bool CheckCollisionWithSides(Position element)
    {
        return element.Row < 0 || element.Column < 0
        || element.Row >= RowNumbers
        || element.Column >= ColumnNumbers;
    }

    protected Position GetFirstObstacleInRoad(Position element, Position move)
    {
        Position newPlace = element + move;

        while (!CheckCollisionWithSides(newPlace))
        {
            if (PlayBoard[newPlace.Row, newPlace.Column] == ' ')
            {
                newPlace += move;
                continue;
            }

            return newPlace;
        }

        return newPlace;
    }

    protected void UpdateMovedElement(char moved, Position oldP, Position newP)
    {
        if (moved == 'O')
        {
            BallPosition[BallPosition.IndexOf(oldP)]
                = new(newP.Row, newP.Column);
        }

        else if (moved == '■')
        {
            MovingWalls![MovingWalls.IndexOf(oldP)]
                = new(newP.Row, newP.Column);
        }

        else if (moved == 'V') BasketPosition = new(newP.Row, newP.Column);

        else if (Coin is not null && moved == '$') Coin = new(newP.Row, newP.Column);
    }

    protected Position Eat(Position obstacle)
    {
        if (CheckCollisionWithSides(obstacle)
            || PlayBoard[obstacle.Row, obstacle.Column] == 'X'
            || PlayBoard[obstacle.Row, obstacle.Column] == '■') return obstacle;

        if (Coin is not null && obstacle == Coin) Coin = null;

        else BallPosition.Remove(obstacle);

        PlayBoard[obstacle.Row, obstacle.Column] = ' ';

        return obstacle + Moves.Up;
    }

    public bool IsFinal()
    {
        if (BallPosition.Count == 0) return true;

        return false;
    }

    public List<Board> MovePossible()
    {
        List<Board> boards = new();

        if (this.IsFinal()) return boards;

        bool thereIsMove;
        string temp;

        (thereIsMove, temp) = CheckMoves(false);

        if (!thereIsMove) return boards;

        for (int i = 0; i < temp.Length; i++)
        {
            switch (temp[i])
            {
                case 'W':
                    Board Up = new(this);
                    Up.MoveUp();
                    boards.Add(Up);
                    break;

                case 'S':
                    Board Down = new(this);
                    Down.MoveDown();
                    boards.Add(Down);
                    break;

                case 'A':
                    Board Left = new(this);
                    Left.MoveLeft();
                    boards.Add(Left);
                    break;

                case 'D':
                    Board Right = new(this);
                    Right.MoveRight();
                    boards.Add(Right);
                    break;
            }
        }

        return boards;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Board board) return false;

        if (RowNumbers != board.RowNumbers
            || ColumnNumbers != board.ColumnNumbers) return false;

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

            if (MovingWalls is not null)
            {
                foreach (var movingWall in MovingWalls)
                {
                    hash.Add(movingWall);
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