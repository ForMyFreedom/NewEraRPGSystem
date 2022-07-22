using Godot;
using Godot.Collections;
using System;

public class BateriaAna : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int staticEletric = RollCode.GetRandomBasicRoll(2);
        int dynamicEletric = main.RequestWorkRoll(relatedWork) / 10;

        return new MessageNotificationData(
            baseMessage, new object[] { staticEletric, dynamicEletric }, criticImage
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
