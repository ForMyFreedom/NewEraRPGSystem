using Godot;
using Godot.Collections;
using System;

public class VentoSolar : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, critic), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
