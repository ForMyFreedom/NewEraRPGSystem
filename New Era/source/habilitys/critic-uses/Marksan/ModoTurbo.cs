using Godot;
using Godot.Collections;
using System;

public class ModoTurbo : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;
        main.CreateNewNotification(
            $"Seu deslocamento aumenta em {3*critic} metros, assim como causa +{critic} Dano",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        //@
    }
}
