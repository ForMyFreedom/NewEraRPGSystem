using Godot;
using Godot.Collections;
using System;

public class DefesaCritica : CriticUse
{
    int holdBonus;
    int index;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            return;

        holdBonus = 2 * critic;
        index = actionIndex;
        ModifySomeDefense(1);

        main.CreateNewNotification(
            $"Defesa Critica! Voce recebe +{holdBonus} em Defesa de {GetBonusText()}");
        ConnectToLastNotification(main);
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
        return (index == 0) ? "Agilidade" : "Forca";
    }
}
