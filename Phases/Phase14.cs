using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase14 : PhaseBase
{


    public Phase14()
    {
        Columns = 4;
        Rows = 4;

        BasketP = new(1, 0);
        BallP = new() { new(1, 3) };
        Coin = new(2, 3);
        Walls = new() { new(0, 3), new(1, 1), new(2, 1), new(3, 3), };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = 'X';

        PlayB[1, 0] = 'V';
        PlayB[1, 1] = 'X';
        PlayB[1, 2] = ' ';
        PlayB[1, 3] = 'O';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = 'X';
        PlayB[2, 2] = ' ';
        PlayB[2, 3] = '$';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = ' ';
        PlayB[3, 3] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
