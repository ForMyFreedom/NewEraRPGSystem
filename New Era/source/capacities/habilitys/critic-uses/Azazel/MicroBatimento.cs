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

        Beat beatSkill = (Beat) main.GetSkillByWorkAndIndex(relatedWork, 0);

        beatLevel = main.GetSkillByWorkAndIndex(relatedWork, 0).GetLevel();
        main.GetWorkNodeByEnum(relatedWork).GetSkillList()[0].DoMechanic(main, beatSkill.GetActionIndex(), beatLevel);


        return new MessageNotificationData(
            baseMessage, new object[] { selfDamage }, injectedWork.GetBaseImage()
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
