using Godot;
using Godot.Collections;
using System;

public class Manipulation : Skill
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName, critic);

        return new MessageNotificationData(
            notificationText, new object[] { result }, effectImage
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