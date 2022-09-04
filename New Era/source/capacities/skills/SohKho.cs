using Godot;
using Godot.Collections;

public class SohKho : Skill     //turn's to GenSoh
{
    [Export(PropertyHint.MultilineText)]
    private string counterMoralText;
    [Export]
    private string counterMoralName;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { skillName, counterMoralName };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        switch (actionIndex)
        {
            case 0:
                return GetBasicSkillUseMessage();
            case 1:
                return GetCounterMoralSkillUseMessage(main);
        }
        return null;
    }


    private MessageNotificationData GetBasicSkillUseMessage()
    {
        return new MessageNotificationData(
            notificationText, new object[] { 3 * level, 2 * level, level }, effectImage
        );
    }


    private MessageNotificationData GetCounterMoralSkillUseMessage(MainInterface main)
    {
        int gensokuLevel = main.GetWorkNodeByEnum(skillPlayerData.GetWorkEnum()).GetLevel();
        return new MessageNotificationData(
            counterMoralText, new object[] { (gensokuLevel+level)/3 }, effectImage
        );
    }



    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}