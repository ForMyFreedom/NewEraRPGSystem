using Godot;
using Godot.Collections;
using System;

public class SimulacrumSolar : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic, 2*critic, 3*critic }, criticImage
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
