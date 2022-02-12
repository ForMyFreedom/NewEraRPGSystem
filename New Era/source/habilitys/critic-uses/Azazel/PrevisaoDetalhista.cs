using Godot;
using Godot.Collections;
using System;

public class PrevisaoDetalhista : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[1].GetSkillName())/10;

        main.CreateNewNotification(
            $"Voce foca em somente uma informacao e recebe +{3*critic} em seu Teste de Previsao",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
