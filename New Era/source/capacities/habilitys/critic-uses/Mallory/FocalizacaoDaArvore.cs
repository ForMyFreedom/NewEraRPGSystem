using Godot;
using Godot.Collections;
using System;

public class FocalizacaoDaArvore : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { critic }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestAtributeRoll(MyEnum.Atribute.MIN) / 10;
    }
}