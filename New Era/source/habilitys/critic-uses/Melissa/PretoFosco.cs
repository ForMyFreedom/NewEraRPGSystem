using Godot;
using Godot.Collections;
using System;

public class PretoFosco : CriticUse
{
    int guard;
    int defense;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork) / 10;

        guard = 2*critic;
        defense = 4 * critic;
        main.AddGuard(guard);
        main.AddActualAgiDefense(-defense);
        //@lost surto e vida a cada turno
        main.CreateNewNotification(GetNotificationText(defense, guard), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
        main.AddActualAgiDefense(defense);
    }

}
