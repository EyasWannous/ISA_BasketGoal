using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal class Phase09 : PhaseBase
{
    public int Columns;
    public int Rows;
    public char[,] PlayB;
    public Position BasketP;
    public Position? Coin;
    public List<Position> BallP;
    public List<Position>? Walls;

    public Phase09()
    {
        Columns = 3;
        Rows = 4;

        BasketP = new(0, 0);
        BallP = new() { new(1, 0), new(1, 1), new(1, 2) };
        Coin = null;
        Walls = new() { new(0, 1), new(2, 0), new(3, 0), new(3, 2) };

        PlayB = new char[Rows, Columns];

        PlayB[0, 0] = 'V';
        PlayB[0, 1] = 'X';
        PlayB[0, 2] = ' ';

        PlayB[1, 0] = 'O';
        PlayB[1, 1] = 'O';
        PlayB[1, 2] = 'O';

        PlayB[2, 0] = 'X';
        PlayB[2, 1] = ' ';
        PlayB[2, 2] = ' ';

        PlayB[3, 0] = 'X';
        PlayB[3, 1] = ' ';
        PlayB[3, 2] = 'X';
    }

    public override BoardNode Load()
    {
        return new BoardNode(new Board(BasketP, BallP, Walls, Coin, Columns, Rows, PlayB));
    }
}
