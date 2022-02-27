using Godot;
using Godot.Collections;
using System;

public class Manipulation : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Manipular" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int mod = 0)
    {
        int result = main.RequestSkillRoll(skillName, mod);
        main.CreateNewNotification(
            $"Caso a Dificuldade de Crenca do teste seje menor que {result}, voce convence o alvo. Do contrario, ele sabe suas intensoes"
            , effectImage);
    }

}