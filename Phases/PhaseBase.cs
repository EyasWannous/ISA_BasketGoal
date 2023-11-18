using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Phases;

internal abstract class PhaseBase
{
    public int Columns { get; set; }
    public int Rows { get; set; }
    public char[,]? PlayB { get; set; }
    public Position? BasketP { get; set; }
    public Position? Coin { get; set; }
    public List<Position>? BallP { get; set; }
    public List<Position>? Walls { get; set; }

    public abstract BoardNode Load();
}
