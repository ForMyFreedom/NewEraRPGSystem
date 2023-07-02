using Godot;
using Godot.Collections;
using System;

public class Harmonizer : Skill
{
    [Export(PropertyHint.MultilineText)]
    private string solveText;
    [Export(PropertyHint.MultilineText)]
    private string inspirationText;
    [Export(PropertyHint.MultilineText)]
    private string repairText;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        Func<MainInterface, int, MessageNotificationData>[] HarmonyActions = new Func<MainInterface, int, MessageNotificationData>[] {
            solveHarmonyAction, inspirateHarmonyAction, repairHarmonyAction
        };


        critic = main.RequestSkillRoll(skillName) / 10;
        return HarmonyActions[actionIndex](main, critic);
    }


    private MessageNotificationData solveHarmonyAction(MainInterface main, int critic)
    {
        return new MessageNotificationData(
            solveText, new object[] { critic }, effectImage
        );
    }

    private MessageNotificationData inspirateHarmonyAction(MainInterface main, int critic)
    {
        return new MessageNotificationData(
            inspirationText, new object[] { critic }, effectImage
        );
    }

    private MessageNotificationData repairHarmonyAction(MainInterface main, int critic)
    {
        return new MessageNotificationData(
            repairText, new object[] { critic }, effectImage
        );
    }


    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}