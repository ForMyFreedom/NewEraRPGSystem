using Godot;
using Godot.Collections;
using System.Linq;
using System;

public class EatTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        Trace famineTrace = GetFamineTrace(main.GetTraces());
        if (famineTrace == null) return null;
        ((FamineTraceMechanic)famineTrace.GetTraceMechanic()).AddFamine(-2);

        return new MessageNotificationData(baseMessage,
            new object[] { ((FamineTraceMechanic)famineTrace.GetTraceMechanic()).GetFamine()},
            trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }


    public Trace GetFamineTrace(Array<Trace> allTraces)
    {
        return allTraces.First(t => t.GetTraceMechanic() is FamineTraceMechanic);
    }



    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
