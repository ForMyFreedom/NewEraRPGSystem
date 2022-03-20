using Godot;
using Godot.Collections;
using System;

public class LevezaNasPatas : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic<0)
            critic = 2 * main.RequestWorkRoll(relatedWork) / 10;

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, critic), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
