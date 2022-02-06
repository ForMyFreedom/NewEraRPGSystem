using Godot;
using Godot.Collections;
using System;

public class RomperCarotida : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        if(critic==-1)
            critic = main.RequestWorkRoll(relatedWork)/10;

        main.CreateNewNotification(
            $"Caso o alvo seja humanoide, sua letalidade aumenta em {critic}",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
