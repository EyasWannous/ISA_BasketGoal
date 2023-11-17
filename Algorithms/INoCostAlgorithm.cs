using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal interface INoCostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; }
    void Solve(BoardNode boardNode, bool solveAll);
    List<BoardNode> GetFinalStates();
}
