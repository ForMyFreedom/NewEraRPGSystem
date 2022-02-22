using Godot;
using Godot.Collections;
using System;

public class PretoFosco : CriticUse
{
    int guard;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork) / 10;

        guard = critic;
        InvertDefenses(main);
        main.AddGuard(guard);
        //@lost surto e vida a cada turno
        main.CreateNewNotification(GetNotificationText(guard), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        InvertDefenses(main);
        main.AddGuard(-guard);
    }

    private void InvertDefenses(MainInterface main)
    {
        int agiDefense = main.GetActualAgiDefense();
        main.SetActualAgiDefense(main.GetActualStrDefense());
        main.SetActualStrDefense(agiDefense);
    }
}
