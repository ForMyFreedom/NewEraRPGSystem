using Godot;
using Godot.Collections;
using System;

public class Craftsman : Skill
{
    [Export(PropertyHint.MultilineText)]
    private string createTextMessage;
    [Export(PropertyHint.MultilineText)]
    private string refactorTextMessage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex=0, int critic = -1)
    {
        int roll = main.RequestSkillRoll(skillName);

        switch (actionIndex)
        {
            case 0:
                return new MessageNotificationData(
                    createTextMessage, new object[] { roll }, effectImage
                );
            case 1:
                return new MessageNotificationData(
                    refactorTextMessage, new object[] { roll }, effectImage
                );
        }

        return null;
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
