using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class UserPlayMode
{
    BoardNode MyBoard { get; set; }

    public UserPlayMode(BoardNode boardNode) => MyBoard = boardNode;

    public void Play()
    {
        Write.Board(MyBoard);
        Write.UsableKeys();

        char Key = ' ';
        int counter = 0;

        while (Key != 'q' && Key != 'Q' && !MyBoard.IsFinal())
        {
            Key = Console.ReadKey(true).KeyChar;

            Console.WriteLine();

            BoardNode temp = new(MyBoard);
            if (MyBoard.Move(Key))
            {
                if (!temp.Equals(MyBoard))
                {
                    Write.CurrentState(MyBoard);
                    counter++;
                }
            }
        }

        if (MyBoard.IsFinal()) Write.CountStates(counter);

        else Write.Sorry();
    }

}
