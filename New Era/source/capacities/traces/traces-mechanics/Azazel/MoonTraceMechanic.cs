using Godot;
using System;

public class MoonTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddExtraDamage(main.GetTotalAtributeValue(MyEnum.Atribute.MIN));

        return new MessageNotificationData(
            baseMessage, null, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-main.GetTotalAtributeValue(MyEnum.Atribute.MIN));
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
