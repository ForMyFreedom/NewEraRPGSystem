using Godot;
using Godot.Collections;
using System;

public class Protect : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Proteger" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0)
    {
        main.CreateNewNotification($"Proteger! Voce recebe {level} pontos de Guarda para distribuir entre todos proximos a voce", effectImage);
    }

}