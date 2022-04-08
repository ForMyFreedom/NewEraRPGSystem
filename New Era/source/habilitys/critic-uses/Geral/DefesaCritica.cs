using Godot;
using Godot.Collections;
using System;

public class DefesaCritica : CriticUse
{
    int holdBonus;
    int index;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic <= 0)
            return null;

        this.main = main;

        holdBonus = 2 * critic;
        index = actionIndex;
        ModifySomeDefense(1);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, holdBonus, GetBonusText() }
        );
    }

    public override void DoEndMechanicLogic()
    {
        ModifySomeDefense(-1);
    }


    private void ModifySomeDefense(int mod)
    {
        if (index == 0)
            main.AddModAgiDefense(mod*holdBonus);
        else
            main.AddModStrDefense(mod*holdBonus);
    }


    private string GetBonusText()
    {
        return (index == 0) ? "AGI" : "STR";
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
