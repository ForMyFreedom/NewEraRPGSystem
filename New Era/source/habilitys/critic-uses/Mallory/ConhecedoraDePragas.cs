using Godot;
using Godot.Collections;
using System;

public class ConhecedoraDePragas : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            MyStatic.GetNotificationText(baseMessage, injectedWork.GetSkillList()[0].GetLevel()),
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
