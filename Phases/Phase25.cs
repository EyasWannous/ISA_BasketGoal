using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase25 : PhaseBase
{

    public Phase25()
    {
        Columns = 4;
        Rows = 5;

        BasketP = new(4, 3);
        BallP = new() { new(4, 0) };
        Coin = new(0, 0);
        Walls = new() { new(0, 1), new(2, 1), new(2, 2), new(4, 2) };

        MovingW = new() { new(3, 0) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = '$';
        PlayB[0, 1] = 'X';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = ' ';
        PlayB[1, 3] = ' ';

        PlayB[2, 0] = ' ';
        PlayB[2, 1] = 'X';
        PlayB[2, 2] = 'X';
        PlayB[2, 3] = ' ';

        PlayB[3, 0] = '■';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = ' ';
        PlayB[3, 3] = ' ';

        PlayB[4, 0] = 'O';
        PlayB[4, 1] = ' ';
        PlayB[4, 2] = 'X';
        PlayB[4, 3] = 'V';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, MovingW));
    }
}
