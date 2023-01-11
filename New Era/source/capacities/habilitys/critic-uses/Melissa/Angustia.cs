using Godot;
using Godot.Collections;
using System;

public class Angustia : CriticUse
{

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int test = main.RequestWorkRoll(relatedWork);

        return new MessageNotificationData(
            baseMessage, new object[] { test }, criticImage
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
