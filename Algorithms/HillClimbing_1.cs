using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class HillClimbing_1 : HillClimbingBase
{
    protected override int CalculateCost(BoardNode boardNode)
    {
        return boardNode.BallPosition.Count;
    }
}
