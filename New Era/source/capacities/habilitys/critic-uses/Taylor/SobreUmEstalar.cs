using Godot;
using Godot.Collections;
using System;

public class SobreUmEstalar : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(baseMessage, new object[] { critic*10, critic, critic/3 }, criticImage);
    }

    public override void DoEndMechanicLogic()
    {
    }
    
    
    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
