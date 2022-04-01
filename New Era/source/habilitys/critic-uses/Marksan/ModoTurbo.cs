using Godot;
using Godot.Collections;
using System;

public class ModoTurbo : CriticUse
{
    int holdCritic;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddExtraDamage(critic);
        holdCritic = critic;

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, 3*critic, critic), injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdCritic);
    }

    public int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
