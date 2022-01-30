using Godot;
using Godot.Collections;
using System;

public class Leadership : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Liderar com Inspiracao", "Liderar Tropas" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0)
    {
        int result = main.RequestSkillRoll(skillName);
        string message = "";

        if (actionIndex == 0)
            message += GetInspirationLeadershipMessage(result);
        else
            message += GetTroopsLeadershipMessage(result);

        main.CreateNewNotification(message, effectImage);
    }

    private string GetInspirationLeadershipMessage(int result)
    {
        int value = result / 10;
        return $"Em meio ao terror, todos seus aliados recebem +{value} Inspiracao!";
    }

    private string GetTroopsLeadershipMessage(int result)
    {
        string message = $"Voce organiza as tropas com um resultado de {result}. Caso falhe, ";
        int roll = RollCode.GetRandomBasicRoll(1);
        if (roll > 2)
            return message+ "apenas metade o obedece";
        else
            return message+ "ninguem obecede suas ordens";
    }
}