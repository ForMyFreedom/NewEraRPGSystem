using Godot;
using Godot.Collections;
using System;

public class FormaDaPrincesaDasAbelhas : CriticUse
{
    int mod = 8;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgility(mod);
        main.AddModStrength(-mod);

        main.CreateNewNotification(partsOfMessage[0], injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-mod);
        main.AddModStrength(mod);
    }
}
