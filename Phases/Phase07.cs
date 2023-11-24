using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase07 : PhaseBase
{

    public Phase07()
    {
        Columns = 3;
        Rows = 4;

        BasketP = new(2, 2);
        BallP = new() { new(3, 1) };
        Coin = null;
        Walls = new() { new(0, 0), new(1, 2), new(3, 2) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = 'X';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = 'X';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = 'V';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = 'O';
        PlayB[3, 2] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
