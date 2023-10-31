using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class BoardNode : Board
{

    public List<BoardNode>? ChildrenNodes { get; set; }

    public BoardNode(Board myBoard) : base(myBoard) { }

    public void GetChildren()
    {
        List<Board> boards = this.MovePossiable();

        if (!boards.Any()) return;

        ChildrenNodes = new();
        boards.ForEach(board =>
        {
            BoardNode boardNode = new(board);
            ChildrenNodes.Add(boardNode);
        });

    }

}


