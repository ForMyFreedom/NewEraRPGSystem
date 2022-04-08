using Godot;
using Godot.Collections;
using System;

public class PretoFosco : CriticUse
{
    int guard;
    int defense;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        guard = 2 * critic;
        defense = -4 * critic;
        main.AddGuard(guard);
        main.AddActualAgiDefense(defense);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, defense, guard }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
        main.AddActualAgiDefense(-defense);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
