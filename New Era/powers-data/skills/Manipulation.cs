using Godot;
using Godot.Collections;
using System;

using Entities;
using Capacities;

public class Manipulation : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Manipular" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        int result = main.RequestSkillRoll(skillName, critic);
        main.CreateNewNotification(
            $"Caso a Dificuldade de Crenca do teste seje menor que {result}, voce convence o alvo. Do contrario, ele sabe suas intensoes"
            , effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

}