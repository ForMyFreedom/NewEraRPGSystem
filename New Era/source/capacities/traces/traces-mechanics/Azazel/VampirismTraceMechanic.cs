using Godot;
using System;

public class VampirismTraceMechanic : TraceMechanic
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int damage = main.GetTotalAtributeValue(MyEnum.Atribute.STR);
        int health = damage/2;

        return new MessageNotificationData(
            baseMessage, new object[] {damage, health}, trace.GetTraceImage()
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
