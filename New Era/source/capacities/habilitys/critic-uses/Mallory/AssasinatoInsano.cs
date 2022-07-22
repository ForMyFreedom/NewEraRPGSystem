using Godot;
using Godot.Collections;
using System;

public class AssasinatoInsano : CriticUse
{
    int extraDamage;
    int agiBonus;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        agiBonus = (int) (main.GetAgility()*0.25f);
        extraDamage = main.GetSkillByWorkAndIndex(relatedWork, 0).GetLevel();

        main.AddModAgility(agiBonus);
        main.AddExtraDamage(extraDamage);

        return new MessageNotificationData(
            baseMessage, new object[] { agiBonus, extraDamage }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-agiBonus);
        main.AddExtraDamage(-extraDamage);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
