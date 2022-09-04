using Godot;
using Godot.Collections;
using System;

public class MicroBatimento : CriticUse
{
    int beatLevel;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 1 || critic > 5)
            critic = 3;

        int totalLife = main.GetTotalLife();
        int selfDamage = (int)(-totalLife * 0.15);
        main.AddActualLife(selfDamage);

        main.AddActualSurge(-10);

        Beat beatSkill = (Beat) main.GetSkillByWorkAndIndex(relatedWork, 0);

        beatLevel = beatSkill.GetLevel();
        beatSkill.DoMechanic(main, critic-1, beatLevel);

        return new MessageNotificationData(
            baseMessage, new object[] { selfDamage }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
