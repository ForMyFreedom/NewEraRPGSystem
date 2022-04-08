using Godot;
using Godot.Collections;
using System;

public class FormaDeCanhao : CriticUse
{
    int holdCritic;
    int defMod = 10;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.AddModAgiDefense(-defMod);
        main.AddModStrDefense(-defMod);
        main.AddModAgility(2*critic);
        holdCritic = critic;


        return new MessageNotificationData(
            baseMessage, new object[] { critic, 2 * critic }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgiDefense(defMod);
        main.AddModStrDefense(defMod);
        main.AddModAgility(-2 * holdCritic);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
