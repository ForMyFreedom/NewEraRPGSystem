using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class LancaVampirica : CriticUse
{
    int holdCritic;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            baseMessage, injectedWork.GetBaseImage()
        );

        //@acionar o talento
    }

    public override void DoEndMechanicLogic()
    {
    }
}
