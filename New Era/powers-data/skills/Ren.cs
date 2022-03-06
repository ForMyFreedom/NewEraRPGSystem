using Godot;
using Godot.Collections;
using System;

public class Ren : Skill
{
    int damage;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ren 1/4", "Rem 1/3", "Rem 1/2", "Ren Total" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        damage = GetDamage(actionIndex, critic);
        main.AddExtraDamage(damage);

        main.CreateNewNotification("Forma de Haki Ren: Voce recebe: " +
            $"+{damage} Dano \n" +
            $"-{damage} em todos seus Testes Sigilosos \n" +
            $"-{damage / 5} Vida a cada turno \n", effectImage
        );

        ConnectToLastNotification(main);

        //@turn lost of life
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damage);
    }


    private int GetDamage(int actionIndex, int mod)
    {
        return (int)(2.5*(level + mod))/(4-actionIndex);
    }
}