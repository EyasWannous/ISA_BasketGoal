using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase40 : PhaseBase
{
    public int Columns;
    public int Rows;
    public char[,] PlayB;
    public Position BasketP;
    public Position? Coin;
    public List<Position> BallP;
    public List<Position>? Walls;

    public List<Position>? MovingW;

    public Phase40()
    {
        Columns = 5;
        Rows = 5;

        BasketP = new(1, 2);
        BallP = new() { new(1, 4), new(4, 2) };
        Coin = null;
        Walls = new()
        {
            new(1, 1), new(2, 0), new(2, 4),
            new(3, 3), new(4, 0)
        };

        MovingW = new() { new(3, 2) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = ' ';
        PlayB[0, 3] = ' ';
        PlayB[0, 4] = ' ';

        PlayB[1, 0] = ' ';
        PlayB[1, 1] = 'X';
        PlayB[1, 2] = 'V';
        PlayB[1, 3] = ' ';
        PlayB[1, 4] = 'O';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = ' ';
        PlayB[2, 3] = ' ';
        PlayB[2, 4] = 'X';

        PlayB[3, 0] = ' ';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = '■';
        PlayB[3, 3] = 'X';
        PlayB[3, 4] = ' ';

        PlayB[4, 0] = 'X';
        PlayB[4, 1] = ' ';
        PlayB[4, 2] = 'O';
        PlayB[4, 3] = ' ';
        PlayB[4, 4] = ' ';

    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB, MovingW));
    }
}
