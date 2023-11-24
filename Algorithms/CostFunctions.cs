using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal static class CostFunctions
{
    public static int WhereIsBalls(BoardNode boardNode)
    {
        int count = boardNode.BallPosition.Count * 2;
        boardNode.BallPosition.ForEach(ball =>
        {
            if (ball.Column == boardNode.BasketPosition.Column) count--;
        });

        return count;
    }

    public static int WhereIsBasket(BoardNode boardNode)
    {
        if (boardNode.BasketPosition.Row == 0) return boardNode.RowNumbers;

        else if (boardNode.BasketPosition.Row == boardNode.RowNumbers - 1) return 0;

        return boardNode.RowNumbers - boardNode.BasketPosition.Row;
    }

    public static int Distance(BoardNode boardNode)
    {
        int cost = 1_000_000_000;
        boardNode.BallPosition.ForEach(ball =>
        {
            cost = Math.Min(
                    cost,
                    Math.Abs(boardNode.BasketPosition.Row - ball.Row)
                    + Math.Abs(boardNode.BasketPosition.Column - ball.Column)
                );
        });

        return cost;
    }
}
