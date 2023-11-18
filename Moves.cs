using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal static class Moves
{
    public static readonly Position _up = new(-1, 0);
    public static readonly Position _down = new(1, 0);
    public static readonly Position _left = new(0, -1);
    public static readonly Position _right = new(0, 1);
}
