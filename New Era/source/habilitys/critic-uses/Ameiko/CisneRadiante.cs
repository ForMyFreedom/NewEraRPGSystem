using Godot;
using Godot.Collections;
using System;

public class CisneRadiante : CriticUse
{
    int holdBonus;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic<0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        holdBonus = 2 * critic;
        main.AddExtraDamage(holdBonus);

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, holdBonus), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdBonus);
    }
}
