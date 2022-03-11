using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class FormaDaPrincesaDasAbelhas : CriticUse
{
    int mod = 8;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgility(mod);
        main.AddModStrength(-mod);

        main.CreateNewNotification(baseMessage, injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-mod);
        main.AddModStrength(mod);
    }
}
