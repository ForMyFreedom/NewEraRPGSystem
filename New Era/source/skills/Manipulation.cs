using Godot;
using Godot.Collections;
using System;

public class Manipulation : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Manipular" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName, critic);
        main.CreateNewNotification(
            $"Caso a Dificuldade de Crenca do teste seje menor que {result}, voce convence o alvo. Do contrario, ele sabe suas intensoes"
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