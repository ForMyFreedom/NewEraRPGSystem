using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;
using Statics.Enums;

public class MaosFermentadas : CriticUse
{
    int mod;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = main.RequestWorkRoll(relatedWork)/10;

        mod = 3 * critic;

        main.CreateNewNotification(GetNotificationText(mod), injectedWork.GetBaseImage());
        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        int orientation = SortOrientation();
        MyEnum.Atribute atribute = SortAtribute();

        string strOrientation = (orientation == 1) ? "Revez" : "Fortuna";
        main.CreateNewNotification(
            $"{strOrientation} em {atribute} por uma hora!", injectedWork.GetBaseImage()
        );
    }

    private int SortOrientation()
    {
        return RollCode.GetRandomCustomRoll(2);
    }

    private MyEnum.Atribute SortAtribute()
    {
        int random = RollCode.GetRandomBasicRoll(1);
        return (MyEnum.Atribute)(random-1);
    }
}
