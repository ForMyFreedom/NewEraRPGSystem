using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class NaoSeraoOsUltimosSocorros : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = (main.RequestWorkRoll(relatedWork)/10) *4;
        
        main.CreateNewNotification(
            GetNotificationText(critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
