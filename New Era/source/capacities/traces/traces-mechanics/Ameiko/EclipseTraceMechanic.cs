using Godot;
using System;

public class EclipseTraceMechanic : TraceMechanic
{

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        //@
        return new MessageNotificationData(
            baseMessage, new object[] { 2 }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
