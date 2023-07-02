using Godot;
using Godot.Collections;
using System;

public class ReverberarChamas : HakiUse
{
    protected override HakiColors[] GetHakiUseColors()
    {
        return new HakiColors[] { HakiColors.AmeikoYellow };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int bonus = (int) (2.5f * critic);
        return new MessageNotificationData(
            baseMessage, new object[] { bonus, bonus }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork)/10;
    }

}
