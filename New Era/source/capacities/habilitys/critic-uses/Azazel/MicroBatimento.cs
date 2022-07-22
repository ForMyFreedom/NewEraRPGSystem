using Godot;
using Godot.Collections;
using System;

public class MicroBatimento : CriticUse
{
    int beatLevel;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0 || critic > 4)
            critic = 2;

        int selfDamage = RollCode.GetRandomBasicRoll(1) + 2;
        main.AddActualLife(-selfDamage);

        Beat beatSkill = (Beat) main.GetSkillByWorkAndIndex(relatedWork, 0);

        beatLevel = main.GetSkillByWorkAndIndex(relatedWork, critic).GetLevel();
        beatSkill.DoMechanic(main, 2, beatLevel);

        main.AddActualSurge(-3);

        return new MessageNotificationData(
            baseMessage, new object[] { selfDamage }, criticImage
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
