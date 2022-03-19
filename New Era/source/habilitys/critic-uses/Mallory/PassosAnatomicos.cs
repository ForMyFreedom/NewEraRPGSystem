using Godot;
using Godot.Collections;
using System;

public class PassosAnatomicos : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestAtributeRoll(MyEnum.Atribute.AGI)/5;
        
        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
