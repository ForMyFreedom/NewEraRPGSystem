using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class TechArmor : CriticUse
{
    int strMod;
    int resMod;
    int surgeMod;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        this.main = main;
        strMod = critic;
        resMod = 3 * critic;
        surgeMod = 2 * critic;

        ModifyAllFactors(1);

        main.CreateNewNotification(
            GetNotificationText(strMod, resMod, surgeMod), injectedWork.GetBaseImage()
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
}
