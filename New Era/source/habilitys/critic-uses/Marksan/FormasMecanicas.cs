using Godot;
using Godot.Collections;
using System;

public class FormasMecanicas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            partsOfMessage[0]+critic+partsOfMessage[1]+injectedWork.GetLevel()/2+partsOfMessage[2],
            injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Lembre-se de remover o bonus concedido!", injectedWork.GetBaseImage());
    }
}
