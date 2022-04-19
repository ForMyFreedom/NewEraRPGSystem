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



    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex=0, int critic = -1)
    {
        rollResult = main.RequestSkillRoll(skillName, critic);
        string message ="";
        
        if(actionIndex==0)
            message += $"Voce cura {GetRepairLife(rollResult)} Vida do alvo\n";
        else
            message += $"Voce aplica {GetCounterDisease(rollResult)} Contra-Peconha {GetDiseaseReduction()}";

        return new MessageNotificationData(
            message, null, effectImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }


    public int GetRepairLife(int result)
    {
        return (result/5) + 2*(result/15);
    }

    public int GetCounterDisease(int result)
    {
        return result / 10;
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
