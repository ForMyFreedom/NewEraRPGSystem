using Godot;
using Godot.Collections;
using System;

public class ModoTurbo : CriticUse
{
    int holdCritic;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddExtraDamage(critic);
        holdCritic = critic;

        main.CreateNewNotification(
            GetNotificationText(3*critic, critic), injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdCritic);
    }
}
