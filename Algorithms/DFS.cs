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

    public DFS() { }

    public DFS(BoardNode boardNode) => BoardNodes.Add(boardNode);

    public void Solve(BoardNode boardNode, bool solveAll)
    {
        if (_breakAll) return;

        if (BoardNodes.Contains(boardNode)) return;

        BoardNodes.Add(boardNode);

        if (!solveAll && boardNode.IsFinal()) _breakAll = true;
        
        boardNode.GetChildren();

        if (boardNode.MyChildren is null) return;

        boardNode.MyChildren.ForEach(child =>
        {
            Solve(child, solveAll);
        });
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

    public void PrintAllStates ()
    {
        foreach (var item in BoardNodes)
        {
            Console.WriteLine(item);
        }
    }
}
