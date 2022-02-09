using Godot;
using Godot.Collections;
using System;

public class MelAnimador : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            $"Voce cura uma quantidade de vida igual a {critic+3}. Perde-se dois polens",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
