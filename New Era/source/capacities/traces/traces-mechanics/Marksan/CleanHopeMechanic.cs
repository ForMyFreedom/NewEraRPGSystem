using Godot;
using System;

public class CleanHopeMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.SetGameDataByKey(SacreMechanic.hopeKey, 0);
        main.SetModDetermination(0);

        return new MessageNotificationData(
            baseMessage, new object[] { }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
