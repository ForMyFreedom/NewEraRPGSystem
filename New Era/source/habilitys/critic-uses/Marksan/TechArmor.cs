using Godot;
using Godot.Collections;
using System;

public class TechArmor : CriticUse
{
    int strMod;
    int resMod;
    int surgeMod;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        this.main = main;
        strMod = critic;
        resMod = 3 * critic;
        surgeMod = 2 * critic;

        ModifyAllFactors(1);

        main.CreateNewNotification(
        MyStatic.GetNotificationText(baseMessage, strMod, resMod, surgeMod), injectedWork.GetBaseImage()
        );
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        ModifyAllFactors(-1);
    }


    private void ModifyAllFactors(int ori)
    {
        main.AddModStrength(ori * strMod);
        main.AddModSurge(-ori * surgeMod);
    }


    public int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
