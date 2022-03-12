using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class ConhecedoraDePragas : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            GetNotificationText(injectedWork.GetSkillList()[0].GetLevel()),
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
