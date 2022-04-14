using Godot;
using Godot.Collections;
using System;

public class CombateDancante : CriticUse
{
    int holdBonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdBonus = 3 * critic;
        main.AddModAgiDefense(holdBonus);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, holdBonus }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(-holdBonus);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
