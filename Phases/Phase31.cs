using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase31 : PhaseBase
{


    public List<Position>? MovingW;

    public Phase31()
    {
        Columns = 5;
        Rows = 5;

        BasketP = new(0, 4);
        BallP = new() { new(0, 3), new(1, 4) };
        Coin = new(2, 0);
        Walls = new()
        {
            new(1, 1), new(1, 3), new(2, 4),
            new(3, 2), new(4, 0),  new(4, 4),
        };

        MovingW = null;

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = '$';
        PlayB[0, 3] = 'O';
        PlayB[0, 4] = 'V';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = 'X';
        PlayB[1, 2] = ' ';
        PlayB[1, 3] = 'X';
        PlayB[1, 4] = 'O';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = ' ';
        PlayB[2, 3] = ' ';
        PlayB[2, 4] = 'X';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = 'X';
        PlayB[3, 3] = ' ';
        PlayB[3, 4] = ' ';

        PlayB[4, 0] = 'X';
        PlayB[4, 1] = ' ';
        PlayB[4, 2] = ' ';
        PlayB[4, 3] = ' ';
        PlayB[4, 4] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB, MovingW));
    }
}
