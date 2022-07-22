using Godot;
using Godot.Collections;
using System;

public class ModoTurbo : CriticUse
{
    int holdCritic;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddExtraDamage(critic);
        holdCritic = critic;


        return new MessageNotificationData(
            baseMessage, new object[] { 3 * critic, critic }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-holdCritic);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
