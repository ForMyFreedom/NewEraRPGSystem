using Godot;
using Godot.Collections;
using System;

public class RomperCarotida : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        main.RequestSkillMechanic(relatedWork, 0, critic);
        /*
        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, critic), injectedWork.GetBaseImage()
        );
        */
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
