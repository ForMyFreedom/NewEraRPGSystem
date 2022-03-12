using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class SurtoCritico : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return;

        int bonus = 2 * critic;
        main.AddActualSurge(bonus);

        main.CreateNewNotification(GetNotificationText(bonus));
    }

    public override void DoEndMechanicLogic()
    {
    }
}
