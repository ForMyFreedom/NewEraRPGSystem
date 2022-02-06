using Godot;
using Godot.Collections;
using System;

public class FormaDeCanhao : CriticUse
{
    int holdCritic;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddModAgiDefense(-10);
        main.AddModStrDefense(-10);
        main.AddAgility(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(
             "Modo Ativado, Forma de Canhao: Voce apenas pode se mover e atacar, assim como tem -10 em todas suas defesas.\n"+
            $"Mas com isso voce recebe +{2*critic} em Agilidade",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgiDefense(10);
        main.AddModStrDefense(10);
        main.AddAgility(-2 * holdCritic);
    }
}
