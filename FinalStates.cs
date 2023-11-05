using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

class FinalStates : BoardNode
{
    public List<BoardNode>? RoadToFinal { get; set; }
    public FinalStates(BoardNode boardNode) : base(boardNode) { }

    public void FillMyRoad()
    {
        RoadToFinal = new() { this };

        BoardNode? temp = this.Father;

        while (temp is not null)
        {
            RoadToFinal.Add(temp);
            temp = temp.Father;
        }

        RoadToFinal.Reverse();
    }

    public int PrintRoadToFinal()
    {
        if (RoadToFinal is null) return 0;

        RoadToFinal.ForEach(state =>
        {
            Console.WriteLine(state);
        });

        return RoadToFinal.Count;
    }
}