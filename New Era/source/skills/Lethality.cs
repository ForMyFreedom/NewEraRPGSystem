using Godot;
using System;

public class Lethality : Skill
{
    public override void DoMechanic(MainInterface main)
    {
        main.CreateNewNotification(
            $"Letalidade! O alvo sofre {level} Dano adicional caso isso zere sua vida"
        , effectImage);
    }
}
