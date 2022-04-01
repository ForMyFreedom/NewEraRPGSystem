using Godot;
using Godot.Collections;
using System;

public class LancaRotativa : CriticUse
{
    int holdCritic;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgiDefense(2*critic);
        main.AddModStrDefense(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, 2*critic), injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(-2 *holdCritic);
        main.AddModStrDefense(-2*holdCritic);
    }


    public int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
