using Godot;
using Godot.Collections;
using System;

public class PrevisaoDetalhista : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName())/10;

        main.CreateNewNotification(
            GetNotificationText(3 * critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}