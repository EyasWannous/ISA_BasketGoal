using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class BFS
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();

    public Queue<BoardNode> NodesQueue { get; set; } = new();

    public BFS() { }

    public BFS(BoardNode boardNode)
    {
        BoardNodes.Add(boardNode);
        NodesQueue.Enqueue(boardNode);
    }

    public void Solve(BoardNode boardNode)
    {
        NodesQueue.Enqueue(boardNode);

        while (NodesQueue.Count > 0)
        {
            BoardNode temp = NodesQueue.Dequeue();

            if (BoardNodes.Contains(temp)) continue;

            BoardNodes.Add(temp);

            temp.GetChildren();

            if (temp.MyChildren is null) continue;

            temp.MyChildren.ForEach(child =>
            {
                NodesQueue.Enqueue(child);
            });

        }
    }

    public List<List<BoardNode>> FillFinalRoads()
    {
        List<BoardNode> finalStates = GetFinalStates();

        if (!finalStates.Any()) return new();

        List<List<BoardNode>> ALLFinalRoads = new();

        finalStates.ForEach(state =>
        {
            BoardNode tempState = state;
            List<BoardNode> boardNodes = new()
            {
                tempState
            };

            while (tempState.Father is not null)
            {
                boardNodes.Add(tempState.Father);
                tempState = tempState.Father;
            }

            ALLFinalRoads.Add(boardNodes);
        });

        return ALLFinalRoads;
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
