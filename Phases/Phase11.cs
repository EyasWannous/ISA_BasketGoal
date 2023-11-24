using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase11 : PhaseBase
{

    public Phase11()
    {
        Columns = 4;
        Rows = 4;

        BasketP = new(2, 1);
        BallP = new() { new(2, 2) };
        Coin = new(1, 2);
        Walls = new() { new(1, 1), new(2, 0), new(2, 3), new(3, 2) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = 'X';
        PlayB[1, 2] = '$';
        PlayB[1, 3] = ' ';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = 'V';
        PlayB[2, 2] = 'O';
        PlayB[2, 3] = 'X';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = 'X';
        PlayB[3, 3] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP!, BallP!, Walls, Coin, Columns, Rows, PlayB!, null));
    }
}
