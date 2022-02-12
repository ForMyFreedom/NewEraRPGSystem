using Godot;
using Godot.Collections;
using System;

public class SangueMagnetico : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            "Se o alvo em geral estiver acima de 25% de Vida, voce recebe "+
           $"+{5*critic} no Teste de Ataque", injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
