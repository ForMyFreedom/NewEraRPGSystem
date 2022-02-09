using Godot;
using Godot.Collections;
using System;

public class FormaHorrendaDeAbelha : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            "Aumenta seu Treino em Akuma no Mi "+
            "em 1|2 ao custo de 10|20 Polens por dia",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
