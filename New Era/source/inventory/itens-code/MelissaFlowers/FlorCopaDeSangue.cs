using Godot;
using System;

public abstract class FlorCopaDeSangue : ItemCode
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int health = (int)(main.GetTotalLife() * 0.2f);

        main.AddActualLife(health);

        item.RemoveQuantity();
        main.UpdateInventory();

        return new MessageNotificationData(
            message, new object[] {health}, main.GetWorkNodeByEnum(MyEnum.Work.AkumaNoMi).GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
