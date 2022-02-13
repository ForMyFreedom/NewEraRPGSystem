using Godot;
using Godot.Collections;
using System;

public class OndaDeChoque : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork) / 10;

        main.CreateNewNotification(
            partsOfMessage[0]+2*critic+partsOfMessage[1]+critic/2+" metros",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
