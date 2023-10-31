//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ISA_BasketGoal;

//internal class Phase1
//{
//    const int tempColumnNumber = 3;
//    const int tempRowNumber = 4;

//    char[,] tempPlayBoard = new char[tempRowNumber, tempColumnNumber];
//    tempPlayBoard[0, 0] = 'X';
//    tempPlayBoard[0, 1] = ' ';
//    tempPlayBoard[0, 2] = ' ';

//    tempPlayBoard[1, 0] = ' ';
//    tempPlayBoard[1, 1] = ' ';
//    tempPlayBoard[1, 2] = '$';

//    tempPlayBoard[2, 0] = 'O';
//    tempPlayBoard[2, 1] = 'X';
//    tempPlayBoard[2, 2] = 'V';
    
//    tempPlayBoard[3, 0] = ' ';
//    tempPlayBoard[3, 1] = ' ';
//    tempPlayBoard[3, 2] = ' ';

//    Position tempBasketPosition = new(2, 2);

//    Position tempCoin = new(1, 2);

//    List<Position> tempBallPosition = new()
//    {
//        new(2, 0)
//    };

//    List<Position> tempFixedWalls = new()
//    {
//        new(0, 0),
//        new(2, 1),
//    };

//}
