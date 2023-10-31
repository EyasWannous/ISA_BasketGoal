// See https://aka.ms/new-console-template for more information
using ISA_BasketGoal;

int tempColumnNumber = 3;
int tempRowNumber = 4;

char[,] tempPlayBoard = new char[tempRowNumber, tempColumnNumber];

tempPlayBoard[0, 0] = 'X';
tempPlayBoard[0, 1] = ' ';
tempPlayBoard[0, 2] = ' ';

tempPlayBoard[1, 0] = ' ';
tempPlayBoard[1, 1] = ' ';
tempPlayBoard[1, 2] = '$';

tempPlayBoard[2, 0] = 'O';
tempPlayBoard[2, 1] = 'X';
tempPlayBoard[2, 2] = 'V';

tempPlayBoard[3, 0] = ' ';
tempPlayBoard[3, 1] = ' ';
tempPlayBoard[3, 2] = ' ';


Position tempBasketPosition = new(2, 2);

Position tempCoin = new(1, 2);

List<Position> tempBallPosition = new()
{
    new(2, 0)
};

List<Position> tempFixedWalls = new()
{
    new(0, 0),
    new(2, 1),
};



Board MyBoard = new(
    basketPosition: tempBasketPosition,
    ballPosition: tempBallPosition,
    fixedWalls: tempFixedWalls,
    coin: tempCoin,
    columnNumbers: tempColumnNumber,
    rowNumbers: tempRowNumber,
    playBoard: tempPlayBoard
    );

Board tempMyBoard = new(MyBoard);

Console.WriteLine();
Console.WriteLine(MyBoard);
Console.WriteLine();

//Console.WriteLine("Press {'W' 'S' 'A' 'D'} To Move.");
//Console.WriteLine("Press 'M' To See Possialbe Moves.");
//Console.WriteLine("Press 'P' To Print Board After Every Possialbe Moves.");
//Console.WriteLine("Press 'Q' To Quit!");



// char Key = ' ';
// int counter = 0;

// while (Key != 'q' && Key != 'Q' && !MyBoard.IsFinal())
// {
//     Key = Console.ReadKey(true).KeyChar;

//     Console.WriteLine();

//     if (MyBoard.Move(Key))
//     {
//         Console.WriteLine("Current State :\n");
//         Console.WriteLine(MyBoard);
//         counter++;
//     }
// }

// if (MyBoard.IsFinal()) Console.WriteLine($"Congratulations, You Won in {counter} Moves");

// else Console.WriteLine("We Are Sorry, You Left");


// ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,

var watch = System.Diagnostics.Stopwatch.StartNew();


BoardNode BoardNode = new(MyBoard);
HashSet<BoardNode> BoardNodes = new();


void Solve(BoardNode boardNode)
{
    if (watch.Elapsed.TotalSeconds == 1200) return;

    if (BoardNodes.Contains(boardNode)) return;

    BoardNodes.Add(boardNode);

    boardNode.GetChildren();

    if (boardNode.ChildrenNodes is null) return;

    boardNode.ChildrenNodes.ForEach(child =>
    {
        Solve(child);
    });
}
Solve(BoardNode);

Console.WriteLine($"Number of States : {BoardNodes.Count}");

watch.Stop();

var elapsed = watch.Elapsed.TotalSeconds;
var elapsedMS = watch.ElapsedMilliseconds;

Console.WriteLine($"Elapsed time is : {elapsed:N1}s");
Console.WriteLine($"Elapsed time is : {elapsedMS:N1}ms");