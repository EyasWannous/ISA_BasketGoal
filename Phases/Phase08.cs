using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase08 : PhaseBase
{
    public int Columns;
    public int Rows;
    public char[,] PlayB;
    public Position BasketP;
    public Position? Coin;
    public List<Position> BallP;
    public List<Position>? Walls;

    public Phase08()
    {
        Columns = 3;
        Rows = 4;

        BasketP = new(0, 2);
        BallP = new() { new(1, 1), new(3, 1) };
        Coin = new(2, 0);
        Walls = new() { new(0, 1), new(2, 1), };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = 'X';
        PlayB[0, 2] = 'V';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = 'O';
        PlayB[1, 2] = ' ';

        PlayB[2, 0] = '$';
        PlayB[2, 1] = 'X';
        PlayB[2, 2] = ' ';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = 'O';
        PlayB[3, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB, null));
    }
}
