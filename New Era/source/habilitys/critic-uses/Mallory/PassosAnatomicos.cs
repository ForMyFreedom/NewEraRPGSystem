using Godot;
using Godot.Collections;
using System;

public class PassosAnatomicos : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic, 2 * critic }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestAtributeRoll(MyEnum.Atribute.AGI) / 10;
    }
}
