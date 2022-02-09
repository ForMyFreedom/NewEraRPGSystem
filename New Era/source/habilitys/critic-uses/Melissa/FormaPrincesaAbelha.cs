using Godot;
using Godot.Collections;
using System;

public class FormaPrincesaAbelha : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgility(8);
        main.AddModStrength(-8);

        main.CreateNewNotification(
            "Voce se tornou mais rapido mas menos forte. "+
            "Pode voar por 20 metros. Limite de Polem: 13",
            injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-8);
        main.AddModStrength(8);
    }
}
