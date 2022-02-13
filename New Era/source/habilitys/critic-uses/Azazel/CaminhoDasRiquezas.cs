using Godot;
using Godot.Collections;
using System;

public class CaminhoDasRiquezas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[0].GetSkillName()) / 10;

        main.CreateNewNotification(
            partsOfMessage[0]+$" +{2*critic} "+partsOfMessage[1],
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
