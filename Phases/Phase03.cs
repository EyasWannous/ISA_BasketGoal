using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase03 : PhaseBase
{

    public Phase03()
    {
        Columns = 3;
        Rows = 3;

        BasketP = new(0, 1);
        BallP = new() { new(2, 1) };
        Coin = null;
        Walls = new() { new(0, 0), new(1, 2), new(2, 0) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = 'X';
        PlayB[0, 1] = 'V';
        PlayB[0, 2] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = 'X';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = 'O';
        PlayB[2, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
