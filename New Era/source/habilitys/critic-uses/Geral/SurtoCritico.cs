using Godot;
using Godot.Collections;
using System;

public class SurtoCritico : CriticUse
{
    int holdBonus;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            return;

        holdBonus = 2 * critic;
        ModifySomeSurge(1);

        main.CreateNewNotification(
            $"Surto Critico! Voce recebe +{holdBonus} em Surto de Acao");
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        ModifySomeSurge(-1);
    }

    
    private void ModifySomeSurge(int mod)
    {
        main.AddModSurge(mod * holdBonus);
    }
}
