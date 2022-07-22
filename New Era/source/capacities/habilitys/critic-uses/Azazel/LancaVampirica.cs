using Godot;
using Godot.Collections;
using System;

public class LancaVampirica : CriticUse
{
    int holdCritic;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddActualSurge(-5);

        return new MessageNotificationData(
            baseMessage, null, criticImage
        );

        //@acionar o talento
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
