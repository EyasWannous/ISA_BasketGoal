using ISA_BasketGoal;
using System.Text.RegularExpressions;

char Key = ' ';

Console.WriteLine('■');

while (Key != 'q' && Key != 'Q')
{
    string? ChosenPhase = "";

    string Keypattern = @"[0-9]";
    bool isValidInput = false;

    Write.PlayMode();

    Key = Console.ReadKey().KeyChar;
    Console.WriteLine();

    while (!Regex.IsMatch(Key.ToString(), Keypattern) && Key != 'q')
    {
        Write.InvalidKey();
        Key = Console.ReadKey().KeyChar;
    }

    if (Key == 'q') continue;

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
        Key = 'q';
        continue;
    }

    PlayManager play = Key switch
    {
        '1' => new("User"),
        '2' => new("DFS"),
        '3' => new("BFS"),
        '4' => new("DFSone"),
        '5' => new("BFSone"),
        '6' => new("UNICOST"),
        '7' => new("HillClimbing_1"),
        '8' => new("HillClimbing_2"),
        '9' => new("HillClimbing_3"),
        '0' => new("AAsterisk"),
        _ => new("User"),
    };

    play.ChooseAPhase(ChosenPhase!);

    Write.Repeat();
    Key = Console.ReadKey().KeyChar;
}