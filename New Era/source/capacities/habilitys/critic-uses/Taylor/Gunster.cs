using Godot;
using Godot.Collections;
using System;

public class Gunster : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = 3 * critic + main.RequestSkillRoll(relatedWork, 0);
        return new MessageNotificationData(baseMessage, new object[] { result }, criticImage);
    }

    public override void DoEndMechanicLogic()
    {
    }
    
    
    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
