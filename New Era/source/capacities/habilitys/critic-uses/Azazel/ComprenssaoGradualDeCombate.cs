using Godot;
using Godot.Collections;
using System;

public class ComprenssaoGradualDeCombate : CriticUse
{
    [Export]
    private String postFocusText;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { (int)(2.5*critic), 3*main.GetMind() }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
