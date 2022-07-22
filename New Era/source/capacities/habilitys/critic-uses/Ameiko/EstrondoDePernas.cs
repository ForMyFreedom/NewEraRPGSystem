using Godot;
using Godot.Collections;
using System;

public class EstrondoDePernas : CriticUse
{
    int holdFallDefense;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdFallDefense = RollCode.GetRandomBasicRoll(6);

        main.AddActualAgiDefense(-holdFallDefense);
        main.AddActualSurge(-10);

        return new MessageNotificationData(
            baseMessage, new object[] { holdFallDefense }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddActualAgiDefense(holdFallDefense);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
