using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms.HillClimbings;

internal class HillClimbing_2 : HillClimbingBase
{
    protected override int CalculateCost(BoardNode boardNode) => CostFunctions.WhereIsBalls(boardNode);
}
