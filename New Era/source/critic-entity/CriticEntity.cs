using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class CriticEntity : Resource
{
    [Export]
    protected bool toDispendSurge = true;
    [Export]
    protected int baseCritic; // -1 -> N

    public int RegulateCritic(MainInterface main, int critic, bool limitFree)
    {
        if (!toDispendSurge) return 0;
        critic = GetCriticIfNotDetermined(main, critic);
        critic = DefineFinalCritic(main, critic, limitFree);
        if (!CanUseThisHability(main, critic))
            return -1;

        ConsumeCritic(main, critic);
        return critic;
    }


    public abstract int RequestCriticTest(MainInterface main);


    protected int GetCriticIfNotDetermined(MainInterface main, int critic)
    {
        if (critic < 0)
            return RequestCriticTest(main);
        else
            return critic;
    }


    private int DefineFinalCritic(MainInterface main, int critic, bool limitFree)
    {
        int maximumUseOfSurge = main.GetMaximumUseOfSurge();
        if (!limitFree && critic > maximumUseOfSurge)  critic = maximumUseOfSurge;
        if (critic < 0) critic = 0;

        if (baseCritic == -1 && !CanUseThisHability(main, critic))
            critic = main.GetActualSurge();

        return critic;
    }


    private bool CanUseThisHability(MainInterface main, int critic)
    {
        if (main.GetActualSurge() < critic)
            return false;
        else
            return true;
    }

    private void ConsumeCritic(MainInterface main, int critic)
    {
        if (toDispendSurge)
            main.AddActualSurge(-critic);
    }
}
