using Godot;
using Godot.Collections;
using System;

public class ModoTurbo : CriticUse
{
    int holdCritic;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddExtraDamage(critic);
        holdCritic = critic;

        main.CreateNewNotification(
            $"Seu deslocamento aumenta em {3*critic} metros, assim como causa +{critic} Dano",
            injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdCritic);
    }
}
