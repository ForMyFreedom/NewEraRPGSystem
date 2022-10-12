using Godot;
using Godot.Collections;
using System;

public class Knowledge : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Buscar Conhecimento" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName);

        return new MessageNotificationData(notificationText, new object[] { result/10, result/30 }, effectImage);
    }

    
    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}