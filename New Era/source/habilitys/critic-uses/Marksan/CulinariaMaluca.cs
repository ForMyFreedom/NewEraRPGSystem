using Godot;
using Godot.Collections;
using System;

public class CulinariaMaluca : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            $"Caso use apenas ingredientes vivos e duvidosos, voce recebe +{3*critic} no Teste de Culinaria",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
    }
}
