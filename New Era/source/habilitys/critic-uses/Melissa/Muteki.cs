using Godot;
using Godot.Collections;
using System;

public class Muteki : CriticUse
{
    int guard;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[0].GetSkillName())/10;

        guard = 4 * critic;
        main.AddGuard(guard);

        main.CreateNewNotification(GetNotificationText(guard), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }

}
