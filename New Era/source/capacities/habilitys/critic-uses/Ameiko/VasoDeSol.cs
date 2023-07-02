using Godot;
using Godot.Collections;
using System;

public class VasoDeSol : HakiUse
{
    protected override HakiColors[] GetHakiUseColors()
    {
        return new HakiColors[] { HakiColors.AmeikoYellow };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int roll = main.RequestAtributeRoll(MyEnum.Atribute.VON);
        int level = injectedWork.GetLevel();

        return new MessageNotificationData(
            baseMessage, new object[] { roll+level }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
