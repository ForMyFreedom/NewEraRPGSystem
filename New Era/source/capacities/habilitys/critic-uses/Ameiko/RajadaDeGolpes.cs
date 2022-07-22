using Godot;
using Godot.Collections;
using System;

public class RajadaDeGolpes : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddActualSurge(-8);

        return new MessageNotificationData(
            baseMessage, null, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
