using Godot;
using Godot.Collections;
using System;

public class FerraoDaRainha : CriticUse
{
    [Export]
    private Texture customImage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(baseMessage, null, customImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.GetActualSurge();
    }
}
