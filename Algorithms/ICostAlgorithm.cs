using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal.Algorithms;

internal interface ICostAlgorithm
{
    public HashSet<BoardNode> BoardNodes { get; set; }
    void Solve(BoardNode boardNode);
    List<BoardNode> GetFinalStates();
}
