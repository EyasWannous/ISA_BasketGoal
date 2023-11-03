using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase10 : PhaseBase
{
    public int Columns;
    public int Rows;
    public char[,] PlayB;
    public Position BasketP;
    public Position? Coin;
    public List<Position> BallP;
    public List<Position>? Walls;

    public Phase10()
    {
        Columns = 3;
        Rows = 4;

        BasketP = new(1, 2);
        BallP = new() { new(2, 0) };
        Coin = null;
        Walls = new() { new(0, 2), new(1, 0), new(2, 2), new(3, 0) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = ' ';
        PlayB[0, 1] = ' ';
        PlayB[0, 2] = 'X';

        PlayB[1, 0] = 'X';
        PlayB[1, 1] = ' ';
        PlayB[1, 2] = 'V';

        PlayB[2, 0] = 'O';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = 'X';

        PlayB[3, 0] = 'X';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = ' ';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB));
    }
}
