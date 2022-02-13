using Godot;
using Godot.Collections;
using System;

public class GarotaIrritante : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName());

        main.CreateNewNotification(
            partsOfMessage[0]+result, injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
