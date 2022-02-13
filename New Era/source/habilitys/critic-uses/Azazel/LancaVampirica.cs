using Godot;
using Godot.Collections;
using System;

public class LancaVampirica : CriticUse
{
    int holdCritic;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            partsOfMessage[0], injectedWork.GetBaseImage());

        //@acionar o talento
    }

    public override void DoEndMechanicLogic()
    {
    }
}
