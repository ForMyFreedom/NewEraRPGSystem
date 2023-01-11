using Godot;
using Godot.Collections;
using System;

public class CeuNegro : HakiUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int criticWant = main.RequestAtributeRoll(MyEnum.Atribute.VON) / 10;
        return new MessageNotificationData(
            baseMessage, new object[] { criticWant }, criticImage
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
