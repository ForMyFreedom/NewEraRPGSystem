using Godot;
using Godot.Collections;
using System.Linq;
using System;

public class EatTraceMechanic : FaminesUserTraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        AddFamine(main, -2);

        return new MessageNotificationData(
            baseMessage, new object[] { GetFamine(main) }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

}
