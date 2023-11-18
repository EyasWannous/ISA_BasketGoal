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
    private UCS _uCS = new();
    private HillClimbing_1 _hC_1 = new();
    private HillClimbing_2 _hC_2 = new();
    private HillClimbing_3 _hC_3 = new();
    private AAsterisk _aA = new();
    private List<BoardNode> _finalStates = new();
    private List<FinalState> _finals = new();
    private BoardNode? _boardNode;
    public PlayManager(string playMode) => _playMode = playMode;

    public bool BuildPhase(int phaseNumber)
    {
        _boardNode = PhaseManager.LoadPhase(phaseNumber);

        return _playMode switch
        {
            "User" => PlayerMode(),
            "DFS" => SolveNoCostAlgorithm(_dFS, true),
            "BFS" => SolveNoCostAlgorithm(_bFS, true),
            "DFSone" => SolveNoCostAlgorithm(_dFS, false),
            "BFSone" => SolveNoCostAlgorithm(_bFS, false),
            "UNICOST" => SolveCostAlgorithm(_uCS),
            "HillClimbing_1" => SolveCostAlgorithm(_hC_1),
            "HillClimbing_2" => SolveCostAlgorithm(_hC_2),
            "HillClimbing_3" => SolveCostAlgorithm(_hC_3),
            "AAsterisk" => SolveCostAlgorithm(_aA),
            _ => false,
        };
    }

    private bool PlayerMode()
    {
        UserPlayMode UPM = new(_boardNode!);
        UPM.Play();
        return true;
    }

    private bool SolveCostAlgorithm(ICostAlgorithm algorithm)
    {
        _watch = System.Diagnostics.Stopwatch.StartNew();

        algorithm.Solve(_boardNode!);
        _finalStates = algorithm.GetFinalStates();

        FillFinal();
        PrintAllRoadsToFinalStates(algorithm.BoardNodes);

        _watch.Stop();

        return true;
    }

    private bool SolveNoCostAlgorithm(INoCostAlgorithm algorithm, bool solveAll)
    {
        _watch = System.Diagnostics.Stopwatch.StartNew();

        algorithm.Solve(_boardNode!, solveAll);
        _finalStates = algorithm.GetFinalStates();

        FillFinal();
        PrintAllRoadsToFinalStates(algorithm.BoardNodes);

        _watch.Stop();

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

            Write.EndOfState(count, counter);

            counter++;
        });

        double elapsed = _watch!.Elapsed.TotalSeconds;
        long elapsedMS = _watch!.ElapsedMilliseconds;

        Write.Statistics(hashBoardNode.Count, elapsed, elapsedMS);
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
            "26" => BuildPhase(26),
            "27" => BuildPhase(27),
            "28" => BuildPhase(28),
            "29" => BuildPhase(29),
            "30" => BuildPhase(30),
            "31" => BuildPhase(31),
            "32" => BuildPhase(32),
            "33" => BuildPhase(33),
            "34" => BuildPhase(34),
            "35" => BuildPhase(35),
            "36" => BuildPhase(36),
            "37" => BuildPhase(37),
            "38" => BuildPhase(38),
            "39" => BuildPhase(39),
            "40" => BuildPhase(40),
            _ => false,
        };
    }
}
