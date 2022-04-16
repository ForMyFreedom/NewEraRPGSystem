using Godot;
using Godot.Collections;
using System;

public class Miragem : CriticUse
{
    int holdGuard;
    int holdDefense;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdGuard = main.GetGuard();
        main.SetGuard(0);

        holdDefense = (int)(critic * 3.5);
        main.AddActualAgiDefense(holdDefense);

        return new MessageNotificationData(baseMessage, new object[] { holdDefense }, injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
        main.SetGuard(holdGuard);
        main.AddActualAgiDefense(-holdDefense);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork)/10;
    }
}
