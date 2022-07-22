using Godot;
using Godot.Collections;
using System;

public class CorPorCor : CriticUse
{
    int holdDamage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdDamage = (int)(1.5*critic);
        main.AddExtraDamage(holdDamage);

        return new MessageNotificationData(
            baseMessage, new object[] { holdDamage }, criticImage
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
}
