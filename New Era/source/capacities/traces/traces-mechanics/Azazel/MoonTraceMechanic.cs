using Godot;
using System;

public class MoonTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddExtraDamage(main.GetAtributeNodeByEnum(MyEnum.Atribute.MIN).GetAtributeTotalValue());

        return new MessageNotificationData(
            baseMessage, null, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-main.GetAtributeNodeByEnum(MyEnum.Atribute.MIN).GetAtributeTotalValue());
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
