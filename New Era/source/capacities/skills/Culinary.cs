using Godot;
using Godot.Collections;
using System;

public class Culinary : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Cozinhar" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestSkillRoll(skillName,critic);
        string message = "Comida pronta! Apos descansarem, todos que se alimentarem recebecem:\n";
        message += GetLifeRegen(result);
        message += GetCriticGain(result);
        message += GetTrainBonus(result);

        return new MessageNotificationData(
            message, null, effectImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }


    private string GetLifeRegen(int result)
    {
        int value = result / 5;
        if (value > 0)
            return $"Cura {value}\n";
        else
            return "";
    }
  
    private string GetCriticGain(int result)
    {
        int value = result / 10;
        if (value > 0)
            return $"+{value} Criticos nos proximos dois testes\n";
        else
            return "";
    }

    private string GetTrainBonus(int result)
    {
        int value = result / 30;
        if (value > 0)
            return $"   +{value} proximo dado de Treino em 4 dias\n";
        else
            return "";
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}