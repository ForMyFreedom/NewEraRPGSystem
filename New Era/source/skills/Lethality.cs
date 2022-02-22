using Godot;
using Godot.Collections;
using System;

public class Lethality : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Assasinar" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int mod = 0)
    {
        main.CreateNewNotification(
            $"Letalidade! O alvo sofre {level+mod} Dano adicional caso isso zere sua vida"
        , effectImage);
    }
}
