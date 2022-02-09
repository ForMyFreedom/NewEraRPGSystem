using Godot;
using Godot.Collections;
using System;

public class FormaDaAbelhaReluzente : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        //@
        main.CreateNewNotification("placeholder", injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
