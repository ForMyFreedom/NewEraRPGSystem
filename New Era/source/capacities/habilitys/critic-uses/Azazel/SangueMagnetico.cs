using Godot;
using Godot.Collections;
using System;

public class SangueMagnetico : CriticUse
{
    int dmg;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        dmg = 3 * critic;
        main.AddExtraDamage(dmg);

        return new MessageNotificationData(
            baseMessage, new object[] { dmg }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-dmg);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
