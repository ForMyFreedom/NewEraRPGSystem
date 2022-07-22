using Godot;
using Godot.Collections;
using System;

public class RomperCarotida : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        main.RequestSkillMechanic(relatedWork, 0, critic);

        return new MessageNotificationData(
            baseMessage, new object[] { critic }, criticImage
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
