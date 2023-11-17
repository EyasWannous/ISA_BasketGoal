using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase02 : PhaseBase
{

    public Phase02()
    {
        Columns = 3;
        Rows = 3;

        BasketP = new(1, 2);
        BallP = new() { new(1, 0) };
        Coin = null;
        Walls = new() { new(0, 2), new(2, 0) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = 'X';

        PlayB[1, 0] = 'O';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = 'V';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB, null));
    }
}