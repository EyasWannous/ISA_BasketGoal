using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase06 : PhaseBase
{


    public Phase06()
    {
        Columns = 3;
        Rows = 4;

        BasketP = new(1, 0);
        BallP = new() { new(2, 1) };
        Coin = null;
        Walls = new() { new(0, 1), new(2, 0), new(2, 2) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = 'X';
        PlayB[0, 2] = ' ';

        PlayB[1, 0] = 'V';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = ' ';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = 'O';
        PlayB[2, 2] = 'X';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB, null));
    }
}
