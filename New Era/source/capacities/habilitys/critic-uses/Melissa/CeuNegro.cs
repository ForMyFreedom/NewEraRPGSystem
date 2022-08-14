using Godot;
using Godot.Collections;
using System;

public class CeuNegro : HakiUse
{
    [Export(PropertyHint.MultilineText)]
    private string endMessage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        critic = GetHakisColorRollResult(main, new[] {HakiColors.MelissaBlack}, critic)/10;

        return new MessageNotificationData(
            baseMessage, new object[] { critic/3 }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification(endMessage, criticImage);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
