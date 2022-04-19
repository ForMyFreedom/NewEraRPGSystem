using Godot;
using Godot.Collections;
using System;

public class LembrancaDoLimiar : CriticUse
{
    int holdGuard;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdGuard = 2 * critic;
        main.AddGuard(holdGuard);

        return new MessageNotificationData(
            baseMessage, new object[] { holdGuard }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-holdGuard);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName()) / 10;
    }
}
