using Godot;
using Godot.Collections;
using System;

public class AquecimentoDeBatalha : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int bonus = main.GetWorkNodeByEnum(relatedWork).GetLevel()/3;
        main.AddActualSurge(-8);

        return new MessageNotificationData(
            baseMessage, new object[] { bonus }, criticImage
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
