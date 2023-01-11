using Godot;
using Godot.Collections;
using System;

public class AquecimentoDeBatalha : CriticUse
{
    private int bonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        bonus = main.GetWorkNodeByEnum(relatedWork).GetLevel()/2;
        main.AddExtraDamage(bonus);

        return new MessageNotificationData(
            baseMessage, new object[] { bonus }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-bonus);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
