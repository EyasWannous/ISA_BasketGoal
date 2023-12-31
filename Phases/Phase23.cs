using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase23 : PhaseBase
{

    public Phase23()
    {
        Columns = 4;
        Rows = 5;

        BasketP = new(4, 1);
        BallP = new() { new(1, 0), new(3, 0), new(4, 0) };
        Coin = null;
        Walls = new() { new(0, 3), new(1, 1), new(2, 0), new(2, 3), new(3, 1), new(4, 3) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = 'X';

        PlayB[1, 0] = 'O';
        PlayB[1, 1] = 'X';
        PlayB[1, 2] = ' ';
        PlayB[1, 3] = ' ';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = ' ';
        PlayB[2, 3] = 'X';

        PlayB[3, 0] = 'O';
        PlayB[3, 1] = 'X';
        PlayB[3, 2] = ' ';
        PlayB[3, 3] = ' ';

        PlayB[4, 0] = 'O';
        PlayB[4, 1] = 'V';
        PlayB[4, 2] = ' ';
        PlayB[4, 3] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
