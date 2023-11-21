using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms.HillClimbings;

internal class HammingDistance : HillClimbingBase
{
    protected override int CalculateCost(BoardNode boardNode) => CostFunctions.Distance(boardNode);
}
