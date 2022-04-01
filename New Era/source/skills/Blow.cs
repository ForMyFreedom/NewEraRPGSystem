using Godot;
using Godot.Collections;
using System;

public class Blow : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Pancada de Forca", "Pancada de Agilidade", "Pancada de Sentidos" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        string message = "Se o alvo tirar menos de ";
        switch (actionIndex)
        {
            case 0:
                message += GetStrengthMessage(main, critic);
                break;
            case 1:
                message += GetAgilityMessage(main, critic);
                break;
            case 2:
                message += GetSensesMessage(main, critic);
                break;
        }

        main.CreateNewNotification(message, effectImage);
    }

    public override void DoEndMechanicLogic()
    {
    }


    private string GetStrengthMessage(MainInterface main, int mod = 0)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.STR, mod);
        return $"{result}, ele causa -{level} de Dano no proximo turno";
    }

    private string GetAgilityMessage(MainInterface main, int mod = 0)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI, mod);
        return $"{result}, ele perde -{level} de movimento [Podendo ficar imovel] pelo proximo turno";
    }

    private string GetSensesMessage(MainInterface main, int mod = 0)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.SEN, mod);
        return $"{result}, ele tem -{level} em todas suas Defesas pelo proximo turno";
    }


    public int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
