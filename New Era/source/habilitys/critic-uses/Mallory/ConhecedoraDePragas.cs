using Godot;
using Godot.Collections;
using System;

public class ConhecedoraDePragas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            partsOfMessage[0]+injectedWork.GetSkillList()[0].GetLevel()+partsOfMessage[1],
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
