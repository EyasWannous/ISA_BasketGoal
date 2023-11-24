using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase30 : PhaseBase
{

    public Phase30()
    {
        Columns = 5;
        Rows = 5;

        BasketP = new(3, 1);
        BallP = new() { new(4, 2), new(4, 3), new(4, 4) };
        Coin = null;
        Walls = new()
        {
            new(0, 0), new(1, 2), new(2, 2),
            new(2, 4), new(3, 0), new(3, 4),
            new(4, 0),  new(4, 1),
        };

        MovingW = null;

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = 'X';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = ' ';
        PlayB[0, 4] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = 'X';
        PlayB[1, 3] = ' ';
        PlayB[1, 4] = ' ';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = 'X';
        PlayB[2, 3] = ' ';
        PlayB[2, 4] = 'X';

        PlayB[3, 0] = 'X';
        PlayB[3, 1] = 'V';
        PlayB[3, 2] = ' ';
        PlayB[3, 3] = ' ';
        PlayB[3, 4] = 'X';

        PlayB[4, 0] = 'X';
        PlayB[4, 1] = 'X';
        PlayB[4, 2] = 'O';
        PlayB[4, 3] = 'O';
        PlayB[4, 4] = 'O';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, MovingW));
    }
}
