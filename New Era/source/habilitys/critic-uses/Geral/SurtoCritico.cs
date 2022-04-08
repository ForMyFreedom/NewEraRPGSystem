using Godot;
using Godot.Collections;
using System;

public class SurtoCritico : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return null;

        int bonus = 2 * critic;
        main.AddActualSurge(bonus);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, bonus }
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
