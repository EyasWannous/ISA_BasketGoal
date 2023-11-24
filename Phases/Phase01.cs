using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase01 : PhaseBase
{

    public Phase01()
    {
        Columns = 3;
        Rows = 3;

        BasketP = new(2, 1);
        BallP = new() { new(0, 1) };
        Coin = null;
        Walls = null;

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = 'O';
        PlayB[0, 2] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = ' ';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = 'V';
        PlayB[2, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
