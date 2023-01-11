using Godot;
using Godot.Collections;
using System;

public class NoiteSemLuar : CriticUse
{

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int decimumHakiLevel = main.GetWorkNodeByEnum(relatedWork).GetLevel()/10;

        return new MessageNotificationData(
            baseMessage, new object[] { decimumHakiLevel, decimumHakiLevel }, criticImage
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
