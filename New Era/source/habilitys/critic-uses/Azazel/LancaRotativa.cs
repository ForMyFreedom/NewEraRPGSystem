using Godot;
using Godot.Collections;
using System;

public class LancaRotativa : CriticUse
{
    int holdCritic;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddModAgiDefense(2*critic);
        main.AddModStrDefense(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(
            "Como acao livre, voce se protege de projeteis com um bonus de "+
           $"{2*critic} em todas suas Defesas", injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(-2 *holdCritic);
        main.AddModStrDefense(-2*holdCritic);
    }
}
