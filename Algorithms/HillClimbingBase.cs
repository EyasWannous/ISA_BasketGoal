using System;
using System.Collections.Generic;

namespace ISA_BasketGoal.Algorithms;

internal abstract class HillClimbingBase : ICostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();
    protected PriorityQueue<BoardNode, int> NodesQueue { get; set; } = new();

    protected abstract int CalculateCost(BoardNode boardNode);

    public void Solve(BoardNode boardNode)
    {
        EnqueueInitialNode(boardNode);

        while (NodesQueue.Count > 0)
        {
            BoardNode current = NodesQueue.Dequeue();

            if (BoardNodes.Contains(current))
                continue;

            BoardNodes.Add(current);

            if (current.IsFinal())
                return;

            EnqueueChildren(current);
        }
    }

    private void EnqueueInitialNode(BoardNode node)
    {
        NodesQueue.Enqueue(node, CalculateCost(node));
    }

    private void EnqueueChildren(BoardNode parent)
    {
        parent.GetChildren();

        if (parent.MyChildren is null)
            return;

        parent.MyChildren.ForEach(child =>
        {
            NodesQueue.Enqueue(child, CalculateCost(child));
        });
    }

}

