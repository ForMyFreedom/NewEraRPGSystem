using Godot;
using Godot.Collections;
using System;

public class FormasMecanicas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            $"Voce recebe {critic} Implementacoes [Aumente +3 Atributos/Oficios de sua escolhe a cada ponto gasto]\n"+
            $"Limite em um unico fator: {injectedWork.GetLevel()/2}. Implementacoes duram um minuto e nao podem ser alteradas nesse tempo",
            injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.CreateNewNotification("Lembre-se de remover o bonus concedido!", injectedWork.GetBaseImage());
    }
}
