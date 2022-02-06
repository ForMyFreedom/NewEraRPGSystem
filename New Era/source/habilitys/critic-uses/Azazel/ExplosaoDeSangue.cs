using Godot;
using Godot.Collections;
using System;

public class ExplosaoDeSangue : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            "Alvo perde 10% de sua Vida Total (Dano Desguardado Fisico) "+
            "caso seu ataque atual nao cause dano (5% caso cause)",
            injectedWork.GetBaseImage());
    }

    public override void DoEndMechanicLogic()
    {
    }
}
