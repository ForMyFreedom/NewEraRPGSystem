using Godot;
using Godot.Collections;
using System;

public class ComidaCondensada : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int bonus = main.GetTotalAtributeValue(MyEnum.Atribute.SEN) / 2;
        int debuff = RollCode.GetRandomBasicRoll(4); 

        return new MessageNotificationData(
            baseMessage, new object[] { bonus,debuff }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
