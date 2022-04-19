using Godot;
using System;

public class TollItens : ItemCode
{
    [Export]
    private int quality;
    [Export]
    private MyEnum.Work workEnum;
    [Export]
    private int skillIndex;
    [Export]
    private int actionIndex; //@

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.RequestSkillMechanic(workEnum, skillIndex, 3 * quality, actionIndex);
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
