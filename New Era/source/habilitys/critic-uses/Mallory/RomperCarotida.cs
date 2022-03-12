using Godot;
using Godot.Collections;
using System;

public class RomperCarotida : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.RequestSkillMechanic(relatedWork, 0, critic);
        /*
        main.CreateNewNotification(
            GetNotificationText(critic), injectedWork.GetBaseImage()
        );
        */
    }

    public override void DoEndMechanicLogic()
    {
    }
}
