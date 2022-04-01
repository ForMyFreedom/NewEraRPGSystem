using Godot;
using Godot.Collections;
using System;

public class LembrancaDoLimiar : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, 2*critic), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }

    public int RequestCriticTest(MainInterface main)
    {
        return main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName()) / 10;
    }
}
