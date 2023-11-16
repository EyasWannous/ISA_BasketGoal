using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal class DFS
{
    private bool _breakAll = false;
    public HashSet<BoardNode> BoardNodes { get; set; } = new();

    public Stack<BoardNode> NodesStack { get; set; } = new();

    public void Solve(BoardNode boardNode, bool solveAll)
    {
        NodesStack.Push(boardNode);
        while (NodesStack.Count > 0)
        {
            if (_breakAll) return;

            BoardNode temp = NodesStack.Pop();

            if (BoardNodes.Contains(temp)) continue;

            BoardNodes.Add(temp);

            if (!solveAll && temp.IsFinal()) _breakAll = true;

            temp.GetChildren();
            if (temp.MyChildren is null) continue;

            temp.MyChildren.ForEach(child =>
            {
                NodesStack.Push(child);
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



// public void Solve(BoardNode boardNode, bool solveAll)
// {

//     if (_breakAll) return;

//     if (BoardNodes.Contains(boardNode)) return;

//     BoardNodes.Add(boardNode);

//     if (!solveAll && boardNode.IsFinal()) _breakAll = true;

//     boardNode.GetChildren();

//     if (boardNode.MyChildren is null) return;

//     boardNode.MyChildren.ForEach(child =>
//     {
//         Solve(child, solveAll);
//     });
// }