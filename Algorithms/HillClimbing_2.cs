using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class HillClimbing_2 : HillClimbingBase
{
    protected override int CalculateCost(BoardNode boardNode)
    {
        return WhereIsBalls(boardNode);
    }

    private int WhereIsBalls(BoardNode boardNode)
    {
        int count = boardNode.BallPosition.Count * 2;
        boardNode.BallPosition.ForEach(ball =>
        {
            if (ball.Column == boardNode.BasketPosition.Column) count--;
        });
        return count;
    }

}
