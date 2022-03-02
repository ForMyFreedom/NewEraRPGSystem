using Godot;
using Godot.Collections;
using System;

public class MicroBatimento : CriticUse
{
    int beatLevel;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int selfDamage = RollCode.GetRandomBasicRoll(1) + 2;
        main.AddActualLife(-selfDamage);

        beatLevel = main.GetSkillByWorkAndIndex(relatedWork, 0).GetLevel();
        main.GetWorkNodeByEnum(relatedWork).GetSkillList()[0].DoMechanic(main, actionIndex, beatLevel);

        main.CreateNewNotification(GetNotificationText(selfDamage), injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
