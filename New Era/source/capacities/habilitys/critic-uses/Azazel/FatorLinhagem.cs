using Godot;
using Godot.Collections;
using System;

public class FatorLinhagem : HakiUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        critic = GetHakisColorRollResult(main, new[] { HakiColors.AzazelRed }, critic)/10;
        return new MessageNotificationData(
            baseMessage, new object[] { critic / 4 }, criticImage, critic
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
