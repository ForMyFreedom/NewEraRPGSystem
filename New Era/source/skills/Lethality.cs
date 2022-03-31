using Godot;
using Godot.Collections;
using System;

public class Lethality : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Assasinar" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            $"Letalidade! O alvo sofre {level+critic} Dano adicional caso isso zere sua vida"
        , effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
