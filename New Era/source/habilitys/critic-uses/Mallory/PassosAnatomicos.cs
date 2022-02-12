using Godot;
using Godot.Collections;
using System;

public class PassosAnatomicos : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestAtributeRoll(MyEnum.Atribute.AGI)/5;
        
        main.CreateNewNotification(
            $"Caso se mova em direcao a um assassinato, voce recebe +{critic} no resultado",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
