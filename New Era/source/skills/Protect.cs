using Godot;
using Godot.Collections;
using System;

public class Protect : Skill
{
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Proteger" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        guard = level + critic;
        main.AddGuard(guard);
        main.CreateNewNotification($"Proteger! Voce recebe {guard} pontos de Guarda para distribuir entre todos proximos a voce", effectImage);
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }

    public int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}