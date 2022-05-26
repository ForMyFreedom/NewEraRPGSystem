using Godot;
using Godot.Collections;
using System;

public class LancaRotativa : CriticUse
{
    float mod = 3.5f;
    int holdCritic;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgiDefense((int)mod*critic);
        main.AddModStrDefense((int)mod *critic);
        holdCritic = critic;

        return new MessageNotificationData(
            baseMessage, new object[] { mod*critic }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense((int)-mod*holdCritic);
        main.AddModStrDefense((int)-mod*holdCritic);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
