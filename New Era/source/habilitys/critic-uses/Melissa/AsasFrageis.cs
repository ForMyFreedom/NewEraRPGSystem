using Godot;
using Godot.Collections;
using System;

public class AsasFrageis : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        if (critic < 0)
            critic = result / 10;

        main.CreateNewNotification(
            MyStatic.GetNotificationText(baseMessage, result, critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
