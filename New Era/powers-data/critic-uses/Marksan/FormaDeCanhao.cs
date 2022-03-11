using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class FormaDeCanhao : CriticUse
{
    int holdCritic;
    int defMod = 10;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddModAgiDefense(-defMod);
        main.AddModStrDefense(-defMod);
        main.AddModAgility(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(GetNotificationText(2*critic), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(defMod);
        main.AddModStrDefense(defMod);
        main.AddModAgility(-2 * holdCritic);
    }
}
