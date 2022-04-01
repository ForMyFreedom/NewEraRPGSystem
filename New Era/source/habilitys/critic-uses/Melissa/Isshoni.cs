using Godot;
using Godot.Collections;
using System;

public class Isshoni : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(baseMessage, injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }

    public int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
