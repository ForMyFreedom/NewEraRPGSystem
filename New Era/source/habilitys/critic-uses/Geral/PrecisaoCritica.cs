using Godot;
using Godot.Collections;
using System;

public class PrecisaoCritica : CriticUse
{
    int holdBonus;
    int index;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return;

        main.CreateNewNotification(
            $"Precisao Critica! Voce recebe +{3*critic} no Teste de Ataque"
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
