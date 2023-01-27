using Godot;
using System;

public class RelaxTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.SetGameDataByKey(Beat.stressKey, 0);
        return new MessageNotificationData(baseMessage, null, trace.GetTraceImage());
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
