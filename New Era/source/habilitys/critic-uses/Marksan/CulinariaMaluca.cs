using Godot;
using Godot.Collections;
using System;

public class CulinariaMaluca : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, 3*critic),injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
