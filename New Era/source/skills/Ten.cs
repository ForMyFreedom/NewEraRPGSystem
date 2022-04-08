using Godot;
using Godot.Collections;
using System;

public class Ten : Skill
{
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ten" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

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