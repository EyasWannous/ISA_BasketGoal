using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal static class Moves
{
    public static readonly Position _upMove = new(-1, 0);
    public static readonly Position _downMove = new(1, 0);
    public static readonly Position _leftMove = new(0, -1);
    public static readonly Position _rightMove = new(0, 1);
}
