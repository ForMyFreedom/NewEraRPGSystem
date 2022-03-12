using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class Prevision : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Prever" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        int result = main.RequestSkillRoll(skillName, critic);
        main.CreateNewNotification(
            $"Caso a Dificuldade de Previsao do teste seje menor que {result}, voce especula e recebe informacoes. Do contrario, voce nao tem a menor ideia"
            , effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

}