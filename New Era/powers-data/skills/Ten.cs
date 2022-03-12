using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class Ten : Skill
{
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ten" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        guard = level + critic;
        main.AddGuard(guard);
        main.CreateNewNotification($"Forma de Haki Ten: + {guard} Guarda", effectImage);
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }
}