using Godot;
using Godot.Collections;
using System;

public class AleijamentoSanguinario : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int roll = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        var intArray = new int[] { 
            roll, 2 * critic, -2 * critic, -2 * critic, (int)(1.5 * critic), 2 * critic
        };

        var effectArray = System.Array.ConvertAll(intArray, e => (object) e);

        return new MessageNotificationData(
            baseMessage, effectArray, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
