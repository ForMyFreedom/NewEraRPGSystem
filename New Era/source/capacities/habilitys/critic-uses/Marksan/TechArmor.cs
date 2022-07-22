using Godot;
using Godot.Collections;
using System;

public class TechArmor : CriticUse
{
    [Export]
    private Texture customImage;

    private Texture lastTexture;

    int strMod;
    int resMod;
    int surgeMod;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        this.main = main;
        strMod = critic;
        resMod = 3 * critic;
        surgeMod = 2 * critic;

        ModifyAllFactors(1);

        lastTexture = main.GetBGTexture();
        main.SetBGTexture(customImage);

        return new MessageNotificationData(
            baseMessage, new object[] { strMod, resMod, surgeMod }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.SetBGTexture(lastTexture);
        ModifyAllFactors(-1);
    }


    private void ModifyAllFactors(int ori)
    {
        main.AddModStrength(ori * strMod);
        main.AddModSurge(-ori * surgeMod);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
