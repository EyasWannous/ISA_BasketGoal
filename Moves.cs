using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal static class Moves
{
    public static readonly Position Up = new(-1, 0);
    public static readonly Position Down = new(1, 0);
    public static readonly Position Left = new(0, -1);
    public static readonly Position Right = new(0, 1);
}
