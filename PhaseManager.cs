﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISA_BasketGoal.Phases;

namespace ISA_BasketGoal;

internal static class PhaseManager
{
    private static int CurrentPhase { get; set; }

    private static List<BoardNode> phases = new()
    {
        new Phase01().Load(),
        new Phase02().Load(),
        new Phase03().Load(),
        new Phase04().Load(),
        new Phase05().Load(),
        new Phase06().Load(),
        new Phase07().Load(),
        new Phase08().Load(),
        new Phase09().Load(),
        new Phase10().Load(),
        new Phase11().Load(),
        new Phase12().Load(),
        new Phase13().Load(),
        new Phase14().Load(),
        new Phase15().Load(),
        new Phase16().Load(),
        new Phase17().Load(),
        new Phase18().Load(),
        new Phase19().Load(),
        new Phase20().Load(),
        new Phase21().Load(),
        new Phase22().Load(),
        new Phase23().Load(),
        new Phase24().Load(),
    };

    public static BoardNode LoadPhase(int PhaseNumber)
    {
        CurrentPhase = PhaseNumber;
        return new(phases[PhaseNumber - 1]);
    }

    public static BoardNode NextPhase()
    {
        CurrentPhase++;
        if (CurrentPhase < phases.Count)
        {
            return LoadPhase(CurrentPhase);
        }
        // Game completed, handle end game logic

        CurrentPhase = 1;
        return LoadPhase(CurrentPhase);
    }

}
