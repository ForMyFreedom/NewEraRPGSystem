using Godot;
using Godot.Collections;
using System;

public class PrecisaoCritica : CriticUse
{
    int holdBonus;
    int index;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            return;

        main.CreateNewNotification(
            partsOfMessage[0]+3*critic+partsOfMessage[1]
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
