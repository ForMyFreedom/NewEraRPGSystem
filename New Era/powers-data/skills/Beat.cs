using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;


public class Beat : Skill
{
    private bool isRelaxed = false;
    private int holdActionIndex;
    private int mod;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ciclo Regular", "Contra Ciclo" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        holdActionIndex = actionIndex;
        this.main = main;

        if (actionIndex == 0)
            DoRegularCicle(critic);
        else
            DoCounterCicle(critic);

    }

    public override void DoEndMechanicLogic()
    {
        if (holdActionIndex == 0)
            ModifyFactors(mod,(isRelaxed)?-1:1);
    }


    private void DoRegularCicle(int critic)
    {
        isRelaxed = !isRelaxed;
        mod = level + critic;

        if (isRelaxed)
        {
            main.CreateNewNotification($"Relaxamento, voce ganhou {mod} Surto de Acao mas perdeu {level} Dano", effectImage);
            ModifyFactors(mod, 1);
        }
        else
        {
            main.CreateNewNotification($"Contracao, voce ganhou {level} Dano mas perdeu {level} Surto de Acao", effectImage);
            ModifyFactors(mod, -1);
        }

        ConnectToLastNotification(main);
    }

    private void DoCounterCicle(int critic)
    {
        main.CreateNewNotification($"Contra ciclo! Voce mantem o batimento atual, e por isso sofre {level/2} de Dano interno", effectImage);
        main.AddActualLife(-level / 2);
        isRelaxed = !isRelaxed;
    }


    private void ModifyFactors(int mod, int ori)
    {
        main.AddModSurge(mod*ori);
        main.AddExtraDamage(-mod*ori);
    }
}
