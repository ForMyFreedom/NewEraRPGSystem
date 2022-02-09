using Godot;
using Godot.Collections;
using System;

public class FerraoPassivo : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork);

        main.CreateNewNotification(
            $"Antes de ser alvo de um ataque, voce devolve {critic} de "+
             "dano para o inimigo (Independente do alvo acertar ou nao)",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
