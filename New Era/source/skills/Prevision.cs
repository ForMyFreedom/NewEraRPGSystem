using Godot;
using Godot.Collections;
using System;

public class Prevision : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Prever" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName, critic);
        main.CreateNewNotification(
            $"Caso a Dificuldade de Previsao do teste seje menor que {result}, voce especula e recebe informacoes. Do contrario, voce nao tem a menor ideia"
            , effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}