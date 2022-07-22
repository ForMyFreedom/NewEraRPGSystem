using Godot;
using Godot.Collections;
using System;

public class FatorLinhagem : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic, critic / 4 }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Remova as Linhagens...", criticImage);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
