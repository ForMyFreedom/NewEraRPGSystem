using Godot;
using Godot.Collections;
using System;

public class Blow : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Pancada de Forca", "Pancada de Agilidade", "Pancada de Sentidos" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0)
    {
        string message = "Se o alvo tirar menos de ";
        switch (actionIndex)
        {
            case 0:
                message += GetStrengthMessage(main);
                break;
            case 1:
                message += GetAgilityMessage(main);
                break;
            case 2:
                message += GetSensesMessage(main);
                break;
        }

        main.CreateNewNotification(message, effectImage);
    }



    private string GetStrengthMessage(MainInterface main)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.STR);
        return $"{result}, ele causa -{level} de Dano no proximo turno";
    }

    private string GetAgilityMessage(MainInterface main)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);
        return $"{result}, ele perde -{level} de movimento [Podendo ficar imovel] pelo proximo turno";
    }

    private string GetSensesMessage(MainInterface main)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.SEN);
        return $"{result}, ele tem -{level} em todas suas Defesas pelo proximo turno";
    }
}
