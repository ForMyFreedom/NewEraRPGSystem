using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class Protect : Skill
{
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Proteger" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        guard = level + critic;
        main.AddGuard(guard);
        main.CreateNewNotification($"Proteger! Voce recebe {guard} pontos de Guarda para distribuir entre todos proximos a voce", effectImage);
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }

}