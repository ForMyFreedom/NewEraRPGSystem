using Godot;
using Godot.Collections;
using System;

public class PressionGun : CriticUse
{
    private int bonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        bonus = main.GetWorkNodeByEnum(relatedWork).GetLevel() / 3;
        main.AddExtraDamage(bonus);
        main.Connect(nameof(MainInterface.technique_released), this, nameof(onTechniqueReleased));
        return new MessageNotificationData(baseMessage, new object[] { bonus }, criticImage);
    }

    private void onTechniqueReleased()
    {
        main.AddActualSurge(-cost);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-bonus);
        main.Disconnect(nameof(MainInterface.technique_released), this, nameof(onTechniqueReleased));
    }
    
    
    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
