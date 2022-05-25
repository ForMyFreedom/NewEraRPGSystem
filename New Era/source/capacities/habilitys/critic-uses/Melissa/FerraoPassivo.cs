using Godot;
using Godot.Collections;
using System;

public class FerraoPassivo : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int dmgBonus = main.GetActualAgiDefense() / 8;

        main.AddActualSurge(-5);

        return new MessageNotificationData(
            baseMessage, new object[] {dmgBonus}, injectedWork.GetBaseImage()
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
