using Godot;
using Godot.Collections;
using System;

public class ConhecedoraDePragas : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification
        ("Em Testes de Conhecimento sobre pragas e epidemias, voce recebe "+
        $"+{injectedWork.GetSkillList()[0].GetLevel()} no teste",
        injectedWork.GetBaseImage());
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
    }
}
