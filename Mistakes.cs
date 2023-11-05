using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class Mistakes
{
    private void MoveFirstMistake() { }
    //public bool Move(char move)
    //{
    //    return move switch
    //    {
    //        'W' or 'w' => MoveUp(),
    //        'S' or 's' => MoveDown(),
    //        'D' or 'd' => MoveRight(),
    //        'A' or 'a' => MoveLeft(),
    //        _ => false,
    //    };
    //}

    private void MoveSecondMistake() { }
    //private bool MoveUp()
    //{
    //    // while (true)
    //    // {

    //    // }

    //    for (int i = 0; i < RowNumbers; i++)
    //    {
    //        for (int j = 0; j < ColumnNumbers; j++)
    //        {
    //            if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

    //            if (!CheckCollisionWithSides(new(i + _upMove.Row, j)) && PlayBoard[i + _upMove.Row, j] == ' ')
    //            {
    //                char temp = PlayBoard[i, j];
    //                PlayBoard[i, j] = ' ';
    //                PlayBoard[i + _upMove.Row, j] = temp;
    //                i = 0;
    //            }
    //        }
    //    }

    //    UpdateAllMovableElement();

    //    return true;
    //}

    private void MoveThirdMistake() { }
    //private bool MoveDown()
    //{
    //    for (int i = RowNumbers - 1; i >= 0; i--)
    //    {
    //        for (int j = 0; j < ColumnNumbers; j++)
    //        {
    //            if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

    //            if (!CheckCollisionWithSides(new(i + _downMove.Row, j)) && PlayBoard[i + _downMove.Row, j] == ' ')
    //            {
    //                char temp = PlayBoard[i, j];
    //                PlayBoard[i, j] = ' ';
    //                PlayBoard[i + _downMove.Row, j] = temp;
    //                i = RowNumbers - 1;
    //            }

    //        }
    //    }

    //    UpdateAllMovableElement();

    //    return true;
    //}

    private void MoveFourthMistake() { }
    //private bool MoveLeft()
    //{
    //    for (int j = 0; j < ColumnNumbers; j++)
    //    {
    //        for (int i = 0; i < RowNumbers; i++)
    //        {
    //            if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

    //            if (!CheckCollisionWithSides(new(i, j + _leftMove.Column)) && PlayBoard[i, j + _leftMove.Column] == ' ')
    //            {
    //                char temp = PlayBoard[i, j];
    //                PlayBoard[i, j] = ' ';
    //                PlayBoard[i, j + _leftMove.Column] = temp;
    //                j = 0;
    //            }
    //        }
    //    }

    //    UpdateAllMovableElement();

    //    return true;
    //}

    private void MoveFifthMistake() { }
    //private bool MoveRight()
    //{
    //    for (int j = ColumnNumbers - 1; j >= 0; j--)
    //    {
    //        for (int i = 0; i < RowNumbers; i++)
    //        {
    //            if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

    //            if (!CheckCollisionWithSides(new(i, j + _rightMove.Column)) && PlayBoard[i, j + _rightMove.Column] == ' ')
    //            {
    //                char temp = PlayBoard[i, j];
    //                PlayBoard[i, j] = ' ';
    //                PlayBoard[i, j + _rightMove.Column] = temp;
    //                j = ColumnNumbers - 1;
    //            }

    //        }
    //    }

    //    UpdateAllMovableElement();

    //    return true;
    //}

    private void MoveSixthMistake() { }
    //private (Position, Position, Position, Position) GetAllMoves(Position element)
    //{
    //    Position up = element + _upMove;
    //    Position down = element + _downMove;
    //    Position right = element + _rightMove;
    //    Position left = element + _leftMove;
    //    return (up, down, right, left);
    //}
    private void FirstMistake() { }
    //private Position Eat(Position obstacle, Position move)
    //{
    //    return move switch
    //    {
    //        Position(-1, 0) => EatUp(obstacle),
    //        Position(1, 0) => EatDown(obstacle),
    //        _ => new Position(0, 0),
    //    };
    //}

    private void SecondMistake() { }
    //private Position EatDown(Position obstacle)
    //{
    //    if (CheckCollisionWithSides(obstacle) || PlayBoard[obstacle.Row, obstacle.Column] == 'X') return obstacle;

    //    if (Coin is not null && obstacle == Coin) Coin = null;

    //    else BallPosition.Remove(obstacle);

    //    PlayBoard[obstacle.Row, obstacle.Column] = ' ';

    //    return obstacle;
    //}

    private void ThirdMistake() { }
    // bool CheckCollisionWithFixedWalls(Position element, Position Move)
    // {
    //     // There is No Walls to Collision with
    //     if (FixedWalls is null) return false;

    //     Position ObstacleInRoad = GetFirstObstacleInRoad(element, Move);

    //     // There is No ObstacleInRoad to Collision with
    //     // if (ObstacleInRoad.Any()) return false;

    //     // Position up, down, right, left;
    //     // (up, down, right, left) = GetAllMoves(element);

    //     bool thereIsCollision = false;
    //     // foreach (var wall in ObstacleInRoad)
    //     // {
    //     //     if (wall == element) // || wall == up || wall == down || wall == right || wall == left
    //     //     {
    //     //         thereIsCollision = true;
    //     //         break;
    //     //     }
    //     // }

    //     return thereIsCollision;
    // }

    private void FourthMistake() { }
    //private Position WhatIsTheMove(Position move)
    //{
    //    return move switch
    //    {
    //        Position(-1, 0) => _upMove,
    //        Position(1, 0) => _downMove,
    //        Position(0, 1) => _rightMove,
    //        Position(0, -1) => _leftMove,
    //        _ => new Position(0, 0),
    //    };
    //}

    private void FifthMistake() { }
    //private Position WhatIsThis(Position element)
    //{
    //    Position? ObstacleInRoad;

    //    if (element == BasketPosition) return BasketPosition;

    //    ObstacleInRoad = GetObstacleInCollection(element, BallPosition);
    //    if (ObstacleInRoad is not null) return ObstacleInRoad;

    //    if (FixedWalls is not null)
    //    {
    //        ObstacleInRoad = GetObstacleInCollection(element, FixedWalls);
    //        if (ObstacleInRoad is not null) return ObstacleInRoad;
    //    }

    //    if (Coin is not null && ObstacleInRoad  is not null && ObstacleInRoad == Coin) return ObstacleInRoad;

    //    return new(0, 0);
    //}

    private void SixthMistake() { }
    //private static Position? GetObstacleInCollection(Position newPlace, List<Position> collection)
    //{
    //    int indexOfNextMove = collection.BinarySearch(newPlace);
    //    return indexOfNextMove >= 0 ? collection[indexOfNextMove] : null;
    //}

    private void SeventhMistake() { }
    //private void UpdateAllMovableElement()
    //{
    //    BallPosition.Clear();

    //    for (int i = 0; i < RowNumbers; i++)
    //    {
    //        for (int j = 0; j < ColumnNumbers; j++)
    //        {
    //            if (PlayBoard[i, j] == ' ' || PlayBoard[i, j] == 'X') continue;

    //            if (PlayBoard[i, j] == 'V')
    //            {
    //                BasketPosition = new(i, j);
    //                continue;
    //            }


    //            if (PlayBoard[i, j] == 'O')
    //            {
    //                BallPosition.Add(new(i, j));
    //                continue;
    //            }

    //            if (Coin is not null && PlayBoard[i, j] == '$') Coin = new(i, j);
    //        }
    //    }
    //}

    public void hashCodeMistake() { }
    // var hash = new HashCode();
    // hash.Add(RowNumbers);
    // hash.Add(ColumnNumbers);
    // hash.Add(PlayBoard);
    // return hash.ToHashCode();

    // int hash = 17;
    // unchecked
    // {
    //     hash = hash * 31 + RowNumbers.GetHashCode();
    //     hash = hash * 31 + ColumnNumbers.GetHashCode();
    //     hash = hash * 31 + PlayBoard.GetHashCode();
    //     return hash;
    // }

    // if (FixedWalls is null && Coin is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, PlayBoard);

    // if (FixedWalls is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, Coin, PlayBoard);

    // if (Coin is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, FixedWalls, PlayBoard);

    // return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, FixedWalls, Coin, PlayBoard);
    // if (FixedWalls is null && Coin is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, PlayBoard);

    // if (FixedWalls is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, Coin, PlayBoard);

    // if (Coin is null) return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, FixedWalls, PlayBoard);

    // return HashCode.Combine(RowNumbers, ColumnNumbers, BasketPosition, BallPosition, FixedWalls, Coin, PlayBoard);
    public void EqualsMistake() { }
    // public override bool Equals(Board board)
    // {
    //     for (int i = 0; i < RowNumbers; i++)
    //     {
    //         for (int j = 0; j < ColumnNumbers; j++)
    //         {
    //             if (this.PlayBoard[i, j] != board.PlayBoard[i, j]) return false;
    //         }
    //     }

    //     return true;
    // }

    public void HashCodeNotAMistake() { }
    // unchecked
    // {
    //     int hash = 17;
    //     hash = hash * 31 + BasketPosition.GetHashCode();

    //     foreach (var ball in BallPosition)
    //     {
    //         hash = hash * 31 + ball.GetHashCode();
    //     }

    //     if (FixedWalls is not null)
    //     {
    //         foreach (var wall in FixedWalls)
    //         {
    //             hash = hash * 31 + wall.GetHashCode();
    //         }
    //     }

    //     if (Coin is not null)
    //     {
    //         hash = hash * 31 + Coin.GetHashCode();
    //     }

    //     for (int i = 0; i < RowNumbers; i++)
    //     {
    //         for (int j = 0; j < ColumnNumbers; j++)
    //         {
    //             hash = hash * 31 + PlayBoard[i, j].GetHashCode();
    //         }
    //     }

    //     return hash;
    // }

    public void BoardNodeMistake() { }
    // public Board MyBoard { get; set; }
    // public BoardNode(Board myBoard, BoardNode boardNode)
    // {
    //     MyBoard = myBoard;
    //     BoardNodes.Add(boardNode);
    // }

    // public BoardNode(Board myBoard, HashSet<BoardNode> boardNodes)
    // {
    //     MyBoard = myBoard;
    //     BoardNodes = boardNodes;
    // }

    // public override int GetHashCode()
    // {
    //     return MyBoard.GetHashCode();
    // }

    public void ClassMistake() { }
    //class HelpFunctions
    //{
    //    public static List<BoardNode> GetFinalStates(HashSet<BoardNode> BoardNodes)
    //    {
    //        List<BoardNode> LBN = new();

    //        foreach (BoardNode item in BoardNodes)
    //        {
    //            if (item.IsFinal()) LBN.Add(item);
    //        }

    //        return LBN;
    //    }

    //}

    public void ConstructorMistake() { }
    //public Board(
    //    int columnNumbers,
    //    int rowNumbers,
    //    char[,] playBoard)
    //{
    //    BasketPosition = new(-1, -1);
    //    BallPosition[0] = new(-1, -1);
    //    ColumnNumbers = columnNumbers;
    //    RowNumbers = rowNumbers;
    //    PlayBoard = playBoard;
    //}

    public void GetFirstObstacleInRoadMistake() { }
    //Position? ObstacleInRoad;


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
}
