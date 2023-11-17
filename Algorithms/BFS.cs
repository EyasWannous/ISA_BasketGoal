using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class BFS : INoCostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();

    public Queue<BoardNode> NodesQueue { get; set; } = new();

    public void Solve(BoardNode boardNode, bool solveAll)
    {
        NodesQueue.Enqueue(boardNode);

        while (NodesQueue.Count > 0)
        {
            BoardNode temp = NodesQueue.Dequeue();

            if (BoardNodes.Contains(temp)) continue;

            BoardNodes.Add(temp);

            if (!solveAll && temp.IsFinal()) return;

            temp.GetChildren();

            if (temp.MyChildren is null) continue;

            temp.MyChildren.ForEach(child =>
            {
                NodesQueue.Enqueue(child);
            });

        }
    }

    public List<BoardNode> GetFinalStates()
    {
        List<BoardNode> LBN = new();

        foreach (var item in BoardNodes)
        {
            if (item.IsFinal()) LBN.Add(item);
        }

        return LBN;
    }

}
