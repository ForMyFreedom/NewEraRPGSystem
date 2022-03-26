using Godot;
using System;

public abstract class FlorCopaDeSangue : ItemCode
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int health = (int)(main.GetTotalLife() * 0.2f);

        main.AddActualLife(health);
        main.CreateNewNotification(
            MyStatic.GetNotificationText(message, health),
            main.GetWorkNodeByEnum(MyEnum.Work.AkumaNoMi).GetBaseImage()
        );

        item.RemoveQuantity();
        main.UpdateInventory();
    }

    public override void DoEndMechanicLogic()
    {
    }
}
