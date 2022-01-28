using Godot;
using System;

public class Medicine : Skill
{
    int rollResult;

    public override void DoMechanic(MainInterface main)
    {
        rollResult = main.RequestSkillRoll(skillName);

        string message ="";
        message += $"Caso queire tratar ferimentos, voce cura {GetRepairLife()} Vida do alvo\n";
        message += $"Caso queire curar uma doenca, voce ganha {GetCounterDisease()} Contra-Peconha {GetDiseaseReduction()}";

        main.CreateNewNotification(message, effectImage);
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

}
