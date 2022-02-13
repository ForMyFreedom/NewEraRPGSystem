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
            partsOfMessage[0]+result+partsOfMessage[1]+critic+partsOfMessage[2], injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
