using Godot;
using System;

public class SacreMechanic : TraceMechanic
{
    public static readonly string hopeKey = "hope";

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int newHope = main.GetDetermination()/3;
        bool isPositive = RollCode.GetRandomCustomRoll(2) == 1;
        newHope += RollCode.GetRandomCustomRoll(1, newHope / 2, isPositive);

        int hope = (int) main.GetGameDataByKey(hopeKey);
        hope += newHope;
        int distorcion = 2 * hope / 5;

        main.SetGameDataByKey(hopeKey, hope);
        main.SetModDetermination(-distorcion);

        return new MessageNotificationData(
            baseMessage, new object[] { hope, distorcion }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
