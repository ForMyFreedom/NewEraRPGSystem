using Godot;
using Godot.Collections;
using System;

public class FerraoPassivo : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            GetNotificationText(critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
