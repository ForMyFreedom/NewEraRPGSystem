using Godot;
using Godot.Collections;
using System.Linq;
using System;

public class CancerMechanic : TraceMechanic
{
    protected static readonly string tumorKey = "tumor";

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int healthGain = main.GetTotalLife()/4;
        main.AddActualLife(healthGain, true);

        int actualTumor = (int) main.GetGameDataByKey(tumorKey);
        actualTumor++;
        main.SetGameDataByKey(tumorKey, actualTumor);


        return new MessageNotificationData(
            baseMessage, new object[] { healthGain, actualTumor }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
