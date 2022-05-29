using Godot;
using Godot.Collections;
using System;

public class BreakRules : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Quebrar regras" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int value = main.RequestSkillRoll(skillName, critic)/50;
        main.AddActualSurge(-2 * value);
        return new MessageNotificationData(notificationText, new object[]{ value, 2*value }, effectImage);
    }

    
    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}