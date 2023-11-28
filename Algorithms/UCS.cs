using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class UCS : ICostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();

    public PriorityQueue<BoardNode, int> NodesQueue { get; set; } = new();

    public void Solve(BoardNode boardNode)
    {
        NodesQueue.Enqueue(boardNode, 0);

        while (NodesQueue.Count > 0)
        {
            BoardNode temp = NodesQueue.Dequeue();

            if (BoardNodes.Contains(temp)) continue;

            BoardNodes.Add(temp);

            if (temp.IsFinal()) return;

            temp.GetChildren();

            if (temp.MyChildren is null) continue;

            temp.MyChildren.ForEach(child =>
            {
                child.Cost = child.Father!.Cost + 1;
                NodesQueue.Enqueue(child, child.Cost);
            });
        }
    }

}
