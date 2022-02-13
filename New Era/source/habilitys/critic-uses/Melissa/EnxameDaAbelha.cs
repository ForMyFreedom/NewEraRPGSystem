using Godot;
using Godot.Collections;
using System;

public class EnxameDaAbelha : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            partsOfMessage[0],
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
