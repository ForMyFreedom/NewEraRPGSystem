using Godot;
using Godot.Collections;
using System;

public class TemporalArt : Skill
{
    [Export]
    private int aprimorationByExtraDay = 5;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = 0;

        if (critic <= 0)
            result = main.RequestSkillRoll(skillName);
        else
            result = critic * 10;

        return new MessageNotificationData(
            notificationText, new object[] { GetCreationDay(), result, aprimorationByExtraDay }, effectImage
        );
    }


    private int GetCreationDay()
    {
        return RollCode.GetRandomCustomRoll(3, 2)-1;
    }


    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
