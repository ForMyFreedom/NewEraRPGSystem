using Godot;
using Godot.Collections;
using System;

public class FormaDaPrincesaDasAbelhas : CriticUse
{
    [Export]
    private Texture customTexture;

    private Texture lastTexture;

    int holdMod;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdMod = (int)(critic / 1.5);
        main.AddModAgility(holdMod);

        lastTexture = main.GetBGTexture();
        main.SetBGTexture(customTexture);

        return new MessageNotificationData(
            baseMessage, new object[] { holdMod }, criticImage
        );

    }

    public override void DoEndMechanicLogic()
    {
        main.AddModAgility(-holdMod);
        main.SetBGTexture(lastTexture);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
