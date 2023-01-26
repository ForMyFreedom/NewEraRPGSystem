using Godot;
using Godot.Collections;
using System;

public class CorPorCor : HakiUse
{
    int holdDamage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        critic = GetHakisColorRollResult(main, critic)/10;

        holdDamage = (int)(1.5f*critic);
        main.AddExtraDamage(holdDamage);

        return new MessageNotificationData(
            baseMessage, new object[] { holdDamage, (int)(holdDamage/5f) }, criticImage, critic
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdDamage);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }

    protected override HakiColors[] GetHakiUseColors()
    {
        return new[] { HakiColors.MelissaBlack };
    }
}
