// See https://aka.ms/new-console-template for more information
using ISA_BasketGoal;
using System.Text.RegularExpressions;

char Key = ' ';

Console.WriteLine('■');

while (Key != 'q' && Key != 'Q')
{
    string? ChoosenPhase = "";

    string ChoosenPhasepattern = @"([1-9]|1[0-9]|2[0-9])";
    string Keypattern = @"[1-6]";


    Console.WriteLine();
    Console.WriteLine("[1]: Manual Mode (User)\r\n[2]: Auto Mode Solve All (DFS)\r\n[3]: Auto Mode Solve All (BFS)");
    Console.WriteLine("[4]: Auto Mode Solve One (DFS)\r\n[5]: Auto Mode Solve One (BFS)\r\n[6]: Auto Mode (Unicost)");
    Console.WriteLine("Please choose one (or \"q\" to quit)");
    Console.WriteLine();

    Key = Console.ReadKey().KeyChar;
    Console.WriteLine();

    while (!Regex.IsMatch(Key.ToString(), Keypattern) && Key != 'q')
    {
        Console.WriteLine();
        Console.WriteLine("Invalid");
        Console.WriteLine("Please choose one (or \"q\" to quit)");
        Console.WriteLine();
        Key = Console.ReadKey().KeyChar;
    }

    if (Key == 'q') continue;

    Console.WriteLine();
    Console.WriteLine("[1]: Phase One\r\n[2]: Phase Two\r\n[3]: Phase Three");
    Console.WriteLine("[4]: Phase Four\r\n[5]: Phase Five\r\n[6]: Phase Six");
    Console.WriteLine("[7]: Phase Seven\r\n[8]: Phase Eight\r\n[9]: Phase Nine");
    Console.WriteLine("[10]: Phase Ten\r\n[11]: Phase Eleven\r\n[12]: Phase Twelve");
    Console.WriteLine("[13]: Phase Thereteen\r\n[14]: Phase Fourteen\r\n[15]: Phase Fifteen");
    Console.WriteLine("[16]: Phase Sixteen\r\n[17]: Phase Seventeen\r\n[18]: Phase Eighteen");
    Console.WriteLine("[19]: Phase Nineteen\r\n[20]: Phase Twenty\r\n[21]: Phase Twenty One");
    Console.WriteLine("[22]: Phase Twenty Two\r\n[23]: Phase Twenty Three\r\n[24]: Phase Twenty Four");
    Console.WriteLine("[25]: Phase Twenty Five\r\n[26]: Phase Twenty Six\r\n[27]: Phase Twenty Seven");
    Console.WriteLine("[28]: Phase Twenty Eight\r\n[29]: Phase Twenty Nine\r\n[30]: Phase Thirty");
    Console.WriteLine("[31]: Phase Thirty One\r\n[32]: Phase Thirty Two\r\n[33]: Phase Thirty Three");
    Console.WriteLine("[34]: Phase Thirty Four\r\n[35]: Phase Thirty Five\r\n[36]: Phase Thirty Six");
    Console.WriteLine("[37]: Phase Thirty Seven\r\n[38]: Phase Thirty Eight\r\n[39]: Phase Thirty Nine");
    Console.WriteLine("[40]: Phase Fourty\r\n");
    Console.WriteLine();


    while (ChoosenPhase != "quit()" && !Regex.IsMatch(ChoosenPhase!, ChoosenPhasepattern))
    {
        Console.WriteLine("Please choose one (or \"quit()\" to quit)");
        ChoosenPhase = Console.ReadLine();
        Console.WriteLine();
    }

    if (ChoosenPhase == "quit()")
    {
        Key = 'q';
        continue;
    }

    if (Key == '1')
    {
        PlayManager play = new("User");
        play.ChooseAPhase(ChoosenPhase!);
    }

    else if (Key == '2')
    {
        PlayManager play = new("DFS");
        play.ChooseAPhase(ChoosenPhase!);
    }

    else if (Key == '3')
    {
        PlayManager play = new("BFS");
        play.ChooseAPhase(ChoosenPhase!);
    }

    else if (Key == '4')
    {
        PlayManager play = new("DFSone");
        play.ChooseAPhase(ChoosenPhase!);
    }

    else if (Key == '5')
    {
        PlayManager play = new("BFSone");
        play.ChooseAPhase(ChoosenPhase!);
    }
    else if (Key == '6')
    {
        PlayManager play = new("UNICOST");
        play.ChooseAPhase(ChoosenPhase!);
    }

    Console.WriteLine();
    Console.WriteLine("To Repeat the game press any Key (or \"q\" to quit)");
    Console.WriteLine();
    Key = Console.ReadKey().KeyChar;
}