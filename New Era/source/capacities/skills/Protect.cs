using Godot;
using Godot.Collections;
using System;

public class Protect : Skill
{
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Proteger" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        guard = level + critic;
        main.AddGuard(guard);

        return new MessageNotificationData(
            notificationText, new object[] { guard }, effectImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}