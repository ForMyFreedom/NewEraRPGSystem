using Godot;
using Godot.Collections;
using System;

public class AsasFrageis : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        if (critic < 0)
            critic = result / 10;

        main.CreateNewNotification(
            "Apos atacar de algum modo, voce faz disputa Agilidade com "+
           $"um alvo [Resultado {result}]. E caso seja melhor, "+
           $"voce rouba {critic} Surto de Acao dele", injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
