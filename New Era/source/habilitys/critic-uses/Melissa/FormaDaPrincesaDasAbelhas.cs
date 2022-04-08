using Godot;
using Godot.Collections;
using System;

public class FormaDaPrincesaDasAbelhas : CriticUse
{
    int holdMod;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdMod = injectedWork.GetLevel() / 3;
        main.AddModAgility(holdMod);

        return new MessageNotificationData(
            baseMessage, new object[] { critic, holdMod }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-holdMod);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
