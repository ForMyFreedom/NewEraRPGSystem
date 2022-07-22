using Godot;
using Godot.Collections;
using System;

public class Compensacao : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddActualSurge(critic/2 -5);

        return new MessageNotificationData(
            baseMessage, new object[] { (int)(1.5*critic) }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
