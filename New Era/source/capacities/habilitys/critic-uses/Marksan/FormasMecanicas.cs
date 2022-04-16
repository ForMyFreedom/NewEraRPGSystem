using Godot;
using Godot.Collections;
using System;

public class FormasMecanicas : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic, injectedWork.GetLevel() / 2 }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Lembre-se de remover o bonus concedido!", injectedWork.GetBaseImage());
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
