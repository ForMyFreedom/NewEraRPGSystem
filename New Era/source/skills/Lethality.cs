using Godot;
using Godot.Collections;
using System;

public class Lethality : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Assasinar" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            notificationText, new object[] { level + critic }, effectImage
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
