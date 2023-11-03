using ISA_BasketGoal.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_BasketGoal;

internal class PlayManager
{
    private string _playMode;
    private System.Diagnostics.Stopwatch? _watch;
    private BFS _bFS = new();
    private DFS _dFS = new();
    private List<BoardNode> _finalStates = new();
    private List<FinalStates> _finals = new();
    private BoardNode? _boardNode;
    public PlayManager(string playMode)
    {
        _playMode = playMode;
    }
    public bool ChooseAPhase(string number)
    {
        return number switch
        {
            "1" => BuildPhase(1),
            "2" => BuildPhase(2),
            "3" => BuildPhase(3),
            "4" => BuildPhase(4),
            "5" => BuildPhase(5),
            "6" => BuildPhase(6),
            "7" => BuildPhase(7),
            "8" => BuildPhase(8),
            "9" => BuildPhase(9),
            "10" => BuildPhase(10),
            "11" => BuildPhase(11),
            "12" => BuildPhase(12),
            "13" => BuildPhase(13),
            "14" => BuildPhase(14),
            "15" => BuildPhase(15),
            _ => false,
        };
    }

    public bool BuildPhase(int phaseNumber)
    {
        _boardNode = PhaseManager.LoadPhase(phaseNumber);

        if (_playMode == "User")
        {
            UserPlayMode UPM = new(_boardNode);
            UPM.Play();
        }
        else if (_playMode == "DFS")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _dFS.Solve(_boardNode);
            _finalStates = _dFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_dFS.BoardNodes);
            _watch.Stop();
        }
        else if (_playMode == "BFS")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _bFS.Solve(_boardNode);
            _finalStates = _bFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_bFS.BoardNodes);
            _watch.Stop();
        }

        return true;
    }

    public void FillFinal()
    {
        _finalStates.ForEach(state =>
        {
            _finals.Add(new(state));
        });
    }

    public void PrintAllRoadsToFinalStates(HashSet<BoardNode> hashBoardNode)
    {
        int counter = 1;
        _finals.ForEach(state =>
        {
            state.FillMyRoad();
            state.PrintRoadToFinal();

            Console.WriteLine("========================================");
            Console.WriteLine($"\tNumber of Final State : {counter}    ");
            Console.WriteLine("========================================");
            Console.WriteLine();

            counter++;
        });
        Console.WriteLine();
        Console.WriteLine($"Number of States : {hashBoardNode.Count}");
        Console.WriteLine();

        double elapsed = _watch!.Elapsed.TotalSeconds;
        long elapsedMS = _watch!.ElapsedMilliseconds;

        Console.WriteLine($"Elapsed time is : {elapsed:N1}s");
        Console.WriteLine($"Elapsed time is : {elapsedMS:N1}ms");
    }
}
