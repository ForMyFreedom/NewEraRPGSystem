using Godot;
using Godot.Collections;
using System;

public class OndaDeChoque : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestWorkRoll(relatedWork) / 10;

        main.CreateNewNotification(
            $"Voce diminui em {2*critic} Surto de Acao todos seres em uma area de 1 a {critic/2} metros",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
    }
}
