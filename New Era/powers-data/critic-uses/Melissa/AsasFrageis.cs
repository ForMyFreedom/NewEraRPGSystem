using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;
using Statics.Enums;

public class AsasFrageis : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        if (critic < 0)
            critic = result / 10;

        main.CreateNewNotification(
            GetNotificationText(result, critic), injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
