using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class HillClimbing_3 : HillClimbingBase
{
    protected override int CalculateCost(BoardNode boardNode)
    {
        return WhereIsBasket(boardNode);
    }

    private int WhereIsBasket(BoardNode boardNode)
    {
        if (boardNode.BasketPosition.Row == 0) return 2;
        if (boardNode.BasketPosition.Row == boardNode.RowNumbers - 1) return 0;
        return 1;
    }

}
