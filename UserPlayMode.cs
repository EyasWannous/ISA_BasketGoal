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
        Console.WriteLine();
        Console.WriteLine(MyBoard);
        Console.WriteLine();
        Console.WriteLine("Press {'W' 'S' 'A' 'D'} To Move.");
        Console.WriteLine("Press 'M' To See Possible Moves.");
        Console.WriteLine("Press 'P' To Print Board After Every Possible Moves.");
        Console.WriteLine("Press 'Q' To Quit!");

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
                    Console.WriteLine("Current State :\n");
                    Console.WriteLine(MyBoard);
                    counter++;
                }
            }
        }

        if (MyBoard.IsFinal()) Console.WriteLine($"Congratulations, You Won in {counter} Moves");

        else Console.WriteLine("We Are Sorry, You Left");
    }

}
