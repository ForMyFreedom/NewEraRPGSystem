using Godot;
using Godot.Collections;
using System;

public class ImpactoOfegante : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            $"O dano de seu ataque vai para zero, mas voce reduz {critic}"+
            " as Defesas do inimigo ate o final do combate [Estacavel]",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
