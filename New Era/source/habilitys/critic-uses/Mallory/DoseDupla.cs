using Godot;
using Godot.Collections;
using System;

public class DoseDupla : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            "Voce sacrifica todas as defesas pelo proximo turno, mas ataque dois alvos!",
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
    }
}
