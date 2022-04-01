using Godot;
using Godot.Collections;
using System;

public class FerraoDaRainha : CriticUse
{
    [Export]
    private Texture customImage;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(baseMessage, customImage);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public int RequestCriticTest(MainInterface main)
    {
        return main.GetActualSurge();
    }
}
