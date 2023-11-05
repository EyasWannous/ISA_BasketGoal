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
    private UniformCost _uni = new();
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
            "16" => BuildPhase(16),
            "17" => BuildPhase(17),
            "18" => BuildPhase(18),
            "19" => BuildPhase(19),
            "20" => BuildPhase(20),
            "21" => BuildPhase(21),
            "22" => BuildPhase(22),
            "23" => BuildPhase(23),
            "24" => BuildPhase(24),
            "25" => BuildPhase(25),
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
            _dFS.Solve(_boardNode, true);
            _finalStates = _dFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_dFS.BoardNodes);
            _watch.Stop();
            //_dFS.PrintAllStates();
        }
        else if (_playMode == "BFS")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _bFS.Solve(_boardNode, true);
            _finalStates = _bFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_bFS.BoardNodes);
            _watch.Stop();
        }
        else if (_playMode == "DFSone")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _dFS.Solve(_boardNode, false);
            _finalStates = _dFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_dFS.BoardNodes);
            _watch.Stop();
        }
        else if (_playMode == "BFSone")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _bFS.Solve(_boardNode, false);
            _finalStates = _bFS.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_bFS.BoardNodes);
            _watch.Stop();
        }
        else if (_playMode == "UNICOST")
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _uni.Solve(_boardNode);
            _finalStates = _uni.GetFinalStates();
            this.FillFinal();
            PrintAllRoadsToFinalStates(_uni.BoardNodes);
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
            int count = state.PrintRoadToFinal();

            Console.WriteLine();
            Console.WriteLine($"\tNumber of States : {count}                   ");
            Console.WriteLine("================================================");
            Console.WriteLine($"\tNumber of this Final State : {counter}       ");
            Console.WriteLine("================================================");
            Console.WriteLine();

            counter++;
        });
        Console.WriteLine();
        Console.WriteLine($"Statistics :");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine($"Number of States : {hashBoardNode.Count}");
        Console.WriteLine();

        double elapsed = _watch!.Elapsed.TotalSeconds;
        long elapsedMS = _watch!.ElapsedMilliseconds;

        Console.WriteLine($"Elapsed time is : {elapsed:N1}s");
        Console.WriteLine($"Elapsed time is : {elapsedMS:N1}ms");
    }
}
