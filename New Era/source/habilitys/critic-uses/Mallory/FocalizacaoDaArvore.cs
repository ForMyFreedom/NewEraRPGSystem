using Godot;
using Godot.Collections;
using System;

public class FocalizacaoDaArvore : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        if (critic == -1)
            critic = main.RequestAtributeRoll(MyEnum.Atribute.MIN)/10;

        main.CreateNewNotification(GetNotificationText(critic), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
