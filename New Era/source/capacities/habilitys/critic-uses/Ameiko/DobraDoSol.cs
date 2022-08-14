using Godot;
using Godot.Collections;
using System;

public class DobraDoSol : HakiUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        critic = GetHakisColorRollResult(main, new[] { HakiColors.AmeikoYellow }, critic)/10;

        var intArray = new int[] {
            3*critic, 2 * critic, 1 * critic, 2 * critic, 1 * critic
        };

        var effectArray = System.Array.ConvertAll(intArray, e => (object)e);

        return new MessageNotificationData(
            baseMessage, effectArray, criticImage, critic
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork)/10;
    }
}
