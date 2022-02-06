using Godot;
using Godot.Collections;
using System;

public class CaminhoDasRiquezas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic == -1)
            critic = main.RequestSkillRoll(injectedWork.GetSkillList()[0].GetSkillName()) / 10;

        main.CreateNewNotification(
            "Voce pode navegar rumo a uma ilha com todos dias recebendo "+
            $"+{2*critic} em todos testes ligados a procurar tesouros",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
