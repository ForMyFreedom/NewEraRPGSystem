using Godot;
using Godot.Collections;
using System;

public class Piloting : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Tracar Mapa" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName, critic);

        return new MessageNotificationData(
            notificationText, new object[] { result, RollCode.GetRandomBasicRoll(25) }, effectImage
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