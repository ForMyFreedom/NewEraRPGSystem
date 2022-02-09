using Godot;
using Godot.Collections;
using System;

public class EnxameDaAbelha : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            "Antes ou depois de atacar, voce pode ir "+
            "da forma reluzente para princesa e vice-versa",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
