using Godot;
using Godot.Collections;
using System;

public class Piloting : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Tracar Mapa" };
    }

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int mod = 0)
    {
        int result = main.RequestSkillRoll(skillName, mod);
        string message =
            $"Apos algum tempo determinado, voce tenta desenhar um mapa com resultado {result}.\n" +
             "Caso passe no teste voce adquire o mapa em quatro horas, do contrario" +
            $"voce era uma medicao nos primeiros {RollCode.GetRandomBasicRoll(25)} minutos [Podendo tentar novamente em uma hora]";

        main.CreateNewNotification(message, effectImage);
    }
}