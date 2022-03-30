using Godot;
using Godot.Collections;
using System;

public class Medicine : Skill
{
    int rollResult;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() {"Medicina de Cura", "Medicina de Tratamento"};
    }



    public override void DoMechanicLogic(MainInterface main, int actionIndex=0, int critic = -1)
    {
        rollResult = main.RequestSkillRoll(skillName, critic);
        string message ="";
        
        if(actionIndex==0)
            message += $"Voce cura {GetRepairLife()} Vida do alvo\n";
        else
            message += $"Voce aplica {GetCounterDisease()} Contra-Peconha {GetDiseaseReduction()}";

        main.CreateNewNotification(message, effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }


    private int GetRepairLife()
    {
        return (int)(rollResult/5)+2*(int)(rollResult/15);
    }

    private int GetCounterDisease()
    {
        return (int)(rollResult / 10);
    }

    private string GetDiseaseReduction()
    {
        int reduction = (int)(rollResult / 30);

        if (reduction > 0)
            return $"[-{reduction} na Peconha]";
        else
            return "";
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
