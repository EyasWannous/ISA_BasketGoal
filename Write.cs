using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal static class Write
{
    public static void ChooseOne()
        => Console.WriteLine("Please choose one (or \"quit()\" to quit)");

    public static void Invalid() => Console.WriteLine("Invalid");

    public static void Repeat()
        => Console.WriteLine("\nTo Repeat the game press any Key (or \"quit()\" to quit)\n");

    public static void UsableKeys()
    {
        Console.WriteLine("Press {'W' 'S' 'A' 'D'} To Move.");
        Console.WriteLine("Press 'M' To See Possible Moves.");
        Console.WriteLine("Press 'P' To Print Board After Every Possible Moves.");
        Console.WriteLine("Press 'Q' To Quit!");
    }

    public static void CountStates(int counter)
        => Console.WriteLine($"Congratulations, You Won in {counter} Moves");

    public static void Sorry() => Console.WriteLine("We Are Sorry, You Left");

    public static void Board(BoardNode board)
        => Console.WriteLine($"\n{board}\n");

    public static void Board(Board board)
        => Console.WriteLine($"\n{board}\n");

    public static void MoveUp() => Console.WriteLine("\nMove Up Using 'W' :\n");

    public static void MoveDown() => Console.WriteLine("\nMove Down Using 'S' :\n");

    public static void MoveLeft() => Console.WriteLine("\nMove Lefts Using 'A' :\n");

    public static void MoveRight() => Console.WriteLine("\nMove Right Using 'D' :\n");

    public static void EndOfState(int count, int counter)
    {
        Console.WriteLine();
        Console.WriteLine($"\tNumber of States : {count}                   ");
        Console.WriteLine("================================================");
        Console.WriteLine($"\tNumber of this Final State : {counter}       ");
        Console.WriteLine("================================================");
        Console.WriteLine();
    }

    public static void Statistics(int count, double elapsed, long elapsedMS)
    {
        Console.WriteLine("\nStatistics :\n");

        Console.WriteLine($"\nNumber of States : {count}\n");

        Console.WriteLine($"Elapsed time is : {elapsed:N1}s");
        Console.WriteLine($"Elapsed time is : {elapsedMS:N1}ms");
    }

    public static void InvalidKey()
    {
        Console.WriteLine();
        Invalid();
        ChooseOne();
        Console.WriteLine();
    }

    public static void CurrentState(BoardNode board)
    {
        Console.WriteLine("Current State :");
        Board(board);
    }

    public static void PlayMode()
    {
        Console.WriteLine();
        Console.WriteLine("[1]: Manual Mode (User)");
        Console.WriteLine("[2]: Auto Mode Solve All (DFS)");
        Console.WriteLine("[3]: Auto Mode Solve All (BFS)");
        Console.WriteLine("[4]: Auto Mode Solve One (DFS)");
        Console.WriteLine("[5]: Auto Mode Solve One (BFS)");
        Console.WriteLine("[6]: Auto Mode (Unicost)");
        Console.WriteLine("[7]: Auto Mode (HillClimbing)");
        Console.WriteLine("[8]: Auto Mode (HillClimbing_2)");
        Console.WriteLine("[9]: Auto Mode (HillClimbing_3)");
        Console.WriteLine("[10]: Auto Mode (ManhattanDistance )");
        Console.WriteLine("[11]: Auto Mode (AAsterisk_1)");
        Console.WriteLine("[12]: Auto Mode (AAsterisk_2)");
        Console.WriteLine("[13]: Auto Mode (AAsterisk_3)");
        Console.WriteLine("[14]: Auto Mode (AManhattanDistance )");
        Console.WriteLine();
        ChooseOne();
        Console.WriteLine();
    }

    public static void Phases()
    {
        Console.WriteLine();
        Console.WriteLine("[1]: Phase One");
        Console.WriteLine("[2]: Phase Two");
        Console.WriteLine("[3]: Phase Three");
        Console.WriteLine("[4]: Phase Four");
        Console.WriteLine("[5]: Phase Five");
        Console.WriteLine("[6]: Phase Six");
        Console.WriteLine("[7]: Phase Seven");
        Console.WriteLine("[8]: Phase Eight");
        Console.WriteLine("[9]: Phase Nine");
        Console.WriteLine("[10]: Phase Ten");
        Console.WriteLine("[11]: Phase Eleven");
        Console.WriteLine("[12]: Phase Twelve");
        Console.WriteLine("[13]: Phase Thereteen");
        Console.WriteLine("[14]: Phase Fourteen");
        Console.WriteLine("[15]: Phase Fifteen");
        Console.WriteLine("[16]: Phase Sixteen");
        Console.WriteLine("[17]: Phase Seventeen");
        Console.WriteLine("[18]: Phase Eighteen");
        Console.WriteLine("[19]: Phase Nineteen");
        Console.WriteLine("[20]: Phase Twenty");
        Console.WriteLine("[21]: Phase Twenty One");
        Console.WriteLine("[22]: Phase Twenty Two");
        Console.WriteLine("[23]: Phase Twenty Three");
        Console.WriteLine("[24]: Phase Twenty Four");
        Console.WriteLine("[25]: Phase Twenty Five");
        Console.WriteLine("[26]: Phase Twenty Six");
        Console.WriteLine("[27]: Phase Twenty Seven");
        Console.WriteLine("[28]: Phase Twenty Eight");
        Console.WriteLine("[29]: Phase Twenty Nine");
        Console.WriteLine("[30]: Phase Thirty");
        Console.WriteLine("[31]: Phase Thirty One");
        Console.WriteLine("[32]: Phase Thirty Two");
        Console.WriteLine("[33]: Phase Thirty Three");
        Console.WriteLine("[34]: Phase Thirty Four");
        Console.WriteLine("[35]: Phase Thirty Five");
        Console.WriteLine("[36]: Phase Thirty Six");
        Console.WriteLine("[37]: Phase Thirty Seven");
        Console.WriteLine("[38]: Phase Thirty Eight");
        Console.WriteLine("[39]: Phase Thirty Nine");
        Console.WriteLine("[40]: Phase Fourty\r\n");
        Console.WriteLine();
        ChooseOne();
        Console.WriteLine();
    }

}
