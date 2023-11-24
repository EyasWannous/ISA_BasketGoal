﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal abstract class AAsteriskBase : ICostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; } = new();
    public PriorityQueue<BoardNode, int> NodesQueue { get; set; } = new();

    public abstract int GetCost(BoardNode boardNode);

    public void Solve(BoardNode boardNode)
    {
        int count = 0;
        NodesQueue.Enqueue(boardNode, GetCost(boardNode));

        while (NodesQueue.Count > 0)
        {
            BoardNode current = NodesQueue.Dequeue();

            if (BoardNodes.Contains(current))
                continue;

            BoardNodes.Add(current);

            if (current.IsFinal())
                return;

            count++;
            EnqueueChildren(current, count);
        }
    }

    private void EnqueueChildren(BoardNode parent, int count)
    {
        parent.GetChildren();

        if (parent.MyChildren is null) return;

        parent.MyChildren.ForEach(child =>
        {
            NodesQueue.Enqueue(child, GetCost(child) + count);
        });
    }

}
