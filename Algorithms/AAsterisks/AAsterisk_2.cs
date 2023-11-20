using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms.AAsterisks;

internal class AAsterisk_2 : AAsteriskBase
{
    public override int GetCost(BoardNode boardNode) => CostFunctions.WhereIsBalls(boardNode);
}
