using Godot;
using Godot.Collections;
using System;

public class PretoFosco : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        InvertDefenses(main);
        main.CreateNewNotification(partsOfMessage[0], injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        InvertDefenses(main);
    }

    private void InvertDefenses(MainInterface main)
    {
        int agiDefense = main.GetActualAgiDefense();
        main.SetActualAgiDefense(main.GetActualStrDefense());
        main.SetActualStrDefense(agiDefense);
    }
}
