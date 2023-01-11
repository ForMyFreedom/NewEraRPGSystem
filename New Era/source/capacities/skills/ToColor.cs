using Godot;
using Godot.Collections;
using System;

public class ToColor : Skill
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(notificationText, new object[] { }, effectImage);
    }

    
    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}