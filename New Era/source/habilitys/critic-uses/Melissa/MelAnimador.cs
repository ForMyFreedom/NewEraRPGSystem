using Godot;
using Godot.Collections;
using System;

public class MelAnimador : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            partsOfMessage[0]+(critic+3)+partsOfMessage[1],
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
