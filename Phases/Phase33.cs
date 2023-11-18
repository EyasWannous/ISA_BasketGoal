using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase33 : PhaseBase
{


    public List<Position>? MovingW;

    public Phase33()
    {
        Columns = 5;
        Rows = 6;

        BasketP = new(5, 0);
        BallP = new() { new(0, 4), new(5, 1), new(5, 3) };
        Coin = null;
        Walls = new()
        {
            new(0, 2), new(1, 4), new(2, 1),
            new(2, 2), new(4, 1), new(4, 3),
            new(5, 4),
        };

        MovingW = null;

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = 'X';
        PlayB[0, 3] = ' ';
        PlayB[0, 4] = 'O';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = ' ';
        PlayB[1, 3] = ' ';
        PlayB[1, 4] = 'X';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = 'X';
        PlayB[2, 2] = 'X';
        PlayB[2, 3] = ' ';
        PlayB[2, 4] = ' ';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = ' ';
        PlayB[3, 3] = ' ';
        PlayB[3, 4] = ' ';

        PlayB[4, 0] = ' ';
        PlayB[4, 1] = 'X';
        PlayB[4, 2] = ' ';
        PlayB[4, 3] = 'X';
        PlayB[4, 4] = ' ';

        PlayB[5, 0] = 'V';
        PlayB[5, 1] = 'O';
        PlayB[5, 2] = ' ';
        PlayB[5, 3] = 'O';
        PlayB[5, 4] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, MovingW));
    }
}
