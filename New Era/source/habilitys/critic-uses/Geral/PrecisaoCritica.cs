using Godot;
using Godot.Collections;
using System;

public class PrecisaoCritica : CriticUse
{
    int holdBonus;
    int index;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return;

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, 3*critic));
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
