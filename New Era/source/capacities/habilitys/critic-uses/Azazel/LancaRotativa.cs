using Godot;
using Godot.Collections;
using System;

public class LancaRotativa : CriticUse
{
    float mod = 3.5f;
    int holdBonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdBonus = (int)(mod * critic);
        main.AddModAgiDefense(holdBonus);
        main.AddModStrDefense(holdBonus);

        return new MessageNotificationData(
            baseMessage, new object[] { holdBonus }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense((int)-holdBonus);
        main.AddModStrDefense((int)-holdBonus);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
