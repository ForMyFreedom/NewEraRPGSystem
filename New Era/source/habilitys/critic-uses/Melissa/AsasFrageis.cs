using Godot;
using Godot.Collections;
using System;

public class AsasFrageis : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            MyStatic.GetNotificationText(baseMessage, 10*critic, critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
    
    
    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestAtributeRoll(MyEnum.Atribute.AGI) / 10;
    }
}
