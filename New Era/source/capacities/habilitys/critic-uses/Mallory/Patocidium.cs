using Godot;
using Godot.Collections;
using System;

public class Patocidium : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        int criticWill = main.RequestAtributeRoll(MyEnum.Atribute.VON) / 10;

        return new MessageNotificationData(
            baseMessage, new object[] { 3*criticWill, 3*criticWill }, criticImage
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
