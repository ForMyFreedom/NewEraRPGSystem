using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;
using Statics.Enums;


public class PassosAnatomicos : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestAtributeRoll(MyEnum.Atribute.AGI)/5;
        
        main.CreateNewNotification(
            GetNotificationText(critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
