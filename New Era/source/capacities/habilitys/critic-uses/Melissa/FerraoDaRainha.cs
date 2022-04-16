using Godot;
using Godot.Collections;
using System;

public class FerraoDaRainha : CriticUse
{
    [Export]
    private Texture customImage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.SetBGTexture(customImage);
        return new MessageNotificationData(baseMessage, null, null);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.GetActualSurge();
    }
}
