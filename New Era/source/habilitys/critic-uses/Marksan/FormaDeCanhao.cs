using Godot;
using Godot.Collections;
using System;

public class FormaDeCanhao : CriticUse
{
    int holdCritic;
    int defMod = 10;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.AddModAgiDefense(-defMod);
        main.AddModStrDefense(-defMod);
        main.AddModAgility(2*critic);
        holdCritic = critic;

        main.CreateNewNotification(
             "Modo Ativado, Forma de Canhao: Voce apenas pode se mover e atacar, assim como tem -10 em todas suas defesas.\n"+
            $"Mas com isso voce recebe +{2*critic} em Agilidade",
            injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(defMod);
        main.AddModStrDefense(defMod);
        main.AddModAgility(-2 * holdCritic);
    }
}
