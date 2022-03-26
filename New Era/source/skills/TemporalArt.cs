using Godot;
using Godot.Collections;
using System;

public class TemporalArt : Skill
{
    [Export]
    private int aprimorationByExtraDay = 5;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Criar Performace" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = 0;
        if (critic < 0)
            result = main.RequestSkillRoll(skillName);
        else
            result = critic * 10;

        main.CreateNewNotification(
             "Escolha um nome e imagine como sera a sua arte \n"+
            $"Ela demora naturalmente {GetCreationDay()} dias para ser criada, "+
            $"com seu Resultado sendo igual a {result} \n [O Narrador lhe dara os valores de Vida e Inspiracao concedidos] \n"+
            $"Para cada dia a mais adicione +{aprimorationByExtraDay} no Resultado", effectImage);
    }


    private int GetCreationDay()
    {
        return RollCode.GetRandomCustomRoll(3, 2)-1;
    }


    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
