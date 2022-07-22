using Godot;
using Godot.Collections;
using System;

public class PensamentoSuicida : CriticUse
{
    [Export(PropertyHint.MultilineText)]
    private string quitMessage;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        main.AddActualSurge(-20);

        return new MessageNotificationData(
            baseMessage, null, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        var willTest = main.RequestAtributeRoll(MyEnum.Atribute.VON);

        main.CreateNewNotification(
            MyStatic.GetNotificationText(quitMessage, 0, new object[] { willTest }),
            criticImage
        );
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
