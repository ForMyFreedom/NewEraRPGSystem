using Godot;
using System;

public class ActivateFamineTraceMechanic : FaminesUserTraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        this.main = main;
        return GetFuryResult(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-dmgBonus);
    }

}
