using Godot;
using Godot.Collections;
using System;

public class MicroBatimento : CriticUse
{
    int beatLevel;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int selfDamage = RollCode.GetRandomBasicRoll(1) + 2;
        main.AddActualLife(-selfDamage);

        beatLevel = main.GetSkillByWorkAndIndex(relatedWork, 0).GetLevel();
        main.GetWorkNodeByEnum(relatedWork).GetSkillList()[0].DoMechanic(main, actionIndex, beatLevel);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, selfDamage }, injectedWork.GetBaseImage()
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
