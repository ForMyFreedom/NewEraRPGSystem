using Godot;
using Godot.Collections;
using System;

public class BreakRules : Skill
{
    [Export(PropertyHint.MultilineText)]
    protected string colorAuraMessageText;
    [Export(PropertyHint.MultilineText)]
    protected string paintMessageText;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Tingir sua Aura", "Pintar a Realidade" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        switch (actionIndex)
        {
            case 0: {
                    int halfLevel = main.GetWorkNodeByEnum(skillPlayerData.GetWorkEnum()).GetLevel() / 2;
                return new MessageNotificationData(colorAuraMessageText, new object[] {halfLevel}, effectImage);
            }
            case 1:
                return new MessageNotificationData(paintMessageText, new object[] { }, effectImage);
            default:
                return new MessageNotificationData(notificationText, new object[] { }, effectImage);
        }
    }

    
    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}