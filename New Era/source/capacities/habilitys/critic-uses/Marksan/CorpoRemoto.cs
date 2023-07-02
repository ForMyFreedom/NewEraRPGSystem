using Godot;
using Godot.Collections;
using System;

public class CorpoRemoto : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int workLevel = main.GetWorkNodeByEnum(relatedWork).GetLevel();
        return new MessageNotificationData(
            baseMessage, new object[] { 2*workLevel }, criticImage
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
