using Godot;
using Godot.Collections;
using System;

public class CombateDancante : CriticUse
{
    int holdBonus;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdBonus = 3 * critic;
        main.AddModAgiDefense(holdBonus);

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, holdBonus), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(-holdBonus);
    }
}
