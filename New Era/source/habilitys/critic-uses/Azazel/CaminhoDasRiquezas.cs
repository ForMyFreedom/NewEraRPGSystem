using Godot;
using Godot.Collections;
using System;

public class CaminhoDasRiquezas : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[0].GetSkillName()) / 10;

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, 2 * critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
