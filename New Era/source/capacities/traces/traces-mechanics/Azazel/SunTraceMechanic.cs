using Godot;
using System;

public class SunTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int damage = main.GetTotalLife()/4;
        main.AddActualLife(-damage);

        return new MessageNotificationData(
            baseMessage, new object[] {damage}, trace.GetTraceImage()
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
