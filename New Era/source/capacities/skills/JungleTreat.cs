using Godot;
using Godot.Collections;
using System;

public class JungleTreat : Skill
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            notificationText, new object[] { level }, effectImage
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
