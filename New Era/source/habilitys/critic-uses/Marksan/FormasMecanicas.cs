using Godot;
using Godot.Collections;
using System;

public class FormasMecanicas : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, critic, injectedWork.GetLevel()/2), injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Lembre-se de remover o bonus concedido!", injectedWork.GetBaseImage());
    }
}
