using Godot;
using Godot.Collections;
using System;

public class LancaRotativa : CriticUse
{
    int holdCritic;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddModAgiDefense(2*critic);
        main.AddModStrDefense(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(
           partsOfMessage[0]+$"{2*critic} "+partsOfMessage[1],
           injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(-2 *holdCritic);
        main.AddModStrDefense(-2*holdCritic);
    }
}
