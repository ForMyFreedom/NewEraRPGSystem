using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class PrecisaoCritica : CriticUse
{
    int holdBonus;
    int index;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return;

        main.CreateNewNotification(GetNotificationText(3*critic));
    }

    public override void DoEndMechanicLogic()
    {
    }
}
