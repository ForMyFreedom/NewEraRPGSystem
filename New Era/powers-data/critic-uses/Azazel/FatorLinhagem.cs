using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class FatorLinhagem : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;
            
        main.CreateNewNotification(GetNotificationText(critic/4), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Remova as Linhagens...", injectedWork.GetBaseImage());
    }
}
