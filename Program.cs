using ISA_BasketGoal;
using System.Text.RegularExpressions;

string Key = " ";

Console.WriteLine("■");

while (Key != "quit()")
{
    string? ChosenPhase = "";

    bool isValidInput = false;

    Write.PlayMode();

    Key = Console.ReadLine()!;
    Console.WriteLine();

    if (Key == "quit()") continue;

    Write.Phases();

    while (!isValidInput && ChosenPhase != "quit()")
    {
        ChosenPhase = Console.ReadLine();

        if (int.TryParse(ChosenPhase, out int phaseNumber)
            && phaseNumber >= 1 && phaseNumber <= 40)
        {
            isValidInput = true;
            continue;
        }

        Write.InvalidKey();
    }

    if (ChosenPhase == "quit()")
    {
        Key = "quit()";
        continue;
    }

    PlayManager play = Key switch
    {
        "1" => new("User"),
        "2" => new("DFS"),
        "3" => new("BFS"),
        "4" => new("DFSone"),
        "5" => new("BFSone"),
        "6" => new("UNICOST"),
        "7" => new("HillClimbing_1"),
        "8" => new("HillClimbing_2"),
        "9" => new("HillClimbing_3"),
        "10" => new("HammingDistance"),
        "11" => new("AAsterisk_1"),
        "12" => new("AAsterisk_2"),
        "13" => new("AAsterisk_3"),
        "14" => new("AHammingDistance"),
        _ => new("User"),
    };

    play.ChooseAPhase(ChosenPhase!);

    Write.Repeat();
    Key = Console.ReadLine()!;
}