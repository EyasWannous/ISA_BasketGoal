using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class BoardNode : Board
{
    public BoardNode? Father { get; set; }

    public int Cost { get; set; } = 0;

    public List<BoardNode>? MyChildren { get; set; }

    public BoardNode(Board myBoard) : base(myBoard) { }

    public BoardNode(Board myBoard, BoardNode Daddy) : base(myBoard) => Father = Daddy;

    public BoardNode(BoardNode boardNode) : base(boardNode)
    {
        if (boardNode.Father is not null) Father = boardNode.Father;

        if (boardNode.MyChildren is not null) MyChildren = boardNode.MyChildren;
    }

    public void GetChildren()
    {
        List<Board> boards = this.MovePossible();

        if (!boards.Any()) return;

        MyChildren = new();
        boards.ForEach(board =>
        {
            BoardNode boardNode = new(board, this);
            MyChildren.Add(boardNode);
        });

    }

}


