using Godot;
using Godot.Collections;
using System;

public class CisneRadiante : CriticUse
{
    int holdBonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdBonus = 2 * critic;
        main.AddExtraDamage(holdBonus);

        return new MessageNotificationData(
            baseMessage, new object[] { holdBonus }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdBonus);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork)/10;
    }
}
