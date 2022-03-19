using Godot;
using Godot.Collections;
using System;

public class SangueMagnetico : CriticUse
{
    int dmg;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        dmg = 3 * critic;
        main.AddExtraDamage(dmg);

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, dmg), injectedWork.GetBaseImage()
        );
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-dmg);
    }
}
