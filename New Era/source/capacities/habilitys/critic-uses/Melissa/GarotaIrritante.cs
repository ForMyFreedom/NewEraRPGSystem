using Godot;
using Godot.Collections;
using System;

public class GarotaIrritante : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic * 10 }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName()) / 10;
    }
}
