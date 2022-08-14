using Godot;
using Godot.Collections;
using System;

public class Resplendor : HakiUse
{
    int holdLife;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        critic = GetHakisColorRollResult(main, new[] {HakiColors.MelissaBlack}, critic)/10;
        holdLife = (int)(critic * 0.35);
        main.AddActualLife(holdLife);
        return new MessageNotificationData(baseMessage, new object[] {holdLife}, criticImage, critic);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddActualLife(-holdLife);
    }
    
    
    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
