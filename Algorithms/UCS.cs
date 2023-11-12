using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class UCS
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();

    public PriorityQueue<BoardNode, int> NodesQueue { get; set; } = new();

    public UCS() { }

    public UCS(BoardNode boardNode) => BoardNodes.Add(boardNode);

    public void Solve(BoardNode boardNode)
    {
        int count = 0;
        NodesQueue.Enqueue(boardNode, count);

        while (NodesQueue.Count > 0)
        {
            BoardNode temp = NodesQueue.Dequeue();

            if (BoardNodes.Contains(temp)) continue;

            BoardNodes.Add(temp);

            if (temp.IsFinal()) return;

            temp.GetChildren();

            if (temp.MyChildren is null) continue;

            count++;
            temp.MyChildren.ForEach(child =>
            {
                NodesQueue.Enqueue(child, count);
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
