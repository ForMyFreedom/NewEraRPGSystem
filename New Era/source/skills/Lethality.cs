using Godot;
using System;

public class Lethality : Skill
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0)
    {
        main.CreateNewNotification(
            $"Letalidade! O alvo sofre {level} Dano adicional caso isso zere sua vida"
        , effectImage);
    }
}
