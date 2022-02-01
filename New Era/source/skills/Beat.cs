using Godot;
using Godot.Collections;
using System;

public class Beat : Skill
{
    private bool isRelaxed = false;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ciclo Regular", "Contra Ciclo" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0)
    {
        if (actionIndex == 0)
            DoRegularCicle(main);
        else
            DoCounterCicle(main);
    }

    private void DoRegularCicle(MainInterface main)
    {
        isRelaxed = !isRelaxed;
        if (isRelaxed)
        {
            main.CreateNewNotification($"Relaxamento, voce ganhou {level} Surto de Acao mas perdeu {level} Dano", effectImage);
            main.AddActualSurge(level);
        }
        else
        {
            main.CreateNewNotification($"Contracao, voce ganhou {level} Dano mas perdeu {level} Surto de Acao", effectImage);
            main.AddActualSurge(-level);
        }
    }

    private void DoCounterCicle(MainInterface main)
    {
        main.CreateNewNotification($"Contra ciclo! Voce mantem o batimento atual, e por isso sofre {level/2} de Dano interno", effectImage);
        main.AddActualLife(-level / 2);
        isRelaxed = !isRelaxed;
        DoRegularCicle(main);
    }
}
