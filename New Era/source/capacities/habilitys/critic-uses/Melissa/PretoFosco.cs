using Godot;
using Godot.Collections;
using System;

public class PretoFosco : CriticUse
{
    [Export]
    private Texture customTexture;

    private Texture lastTexture;

    int guard;
    int defense;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        guard = 2 * critic;
        defense = -4 * critic;
        main.AddGuard(guard);
        main.AddActualAgiDefense(defense);

        lastTexture = main.GetBGTexture();
        main.SetBGTexture(customTexture);

        return new MessageNotificationData(
            baseMessage, new object[] { defense, guard }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
        main.AddActualAgiDefense(-defense);
        main.SetBGTexture(lastTexture);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
