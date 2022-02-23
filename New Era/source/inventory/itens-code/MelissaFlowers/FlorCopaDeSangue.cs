using Godot;
using System;

public abstract class FlorCopaDeSangue : ItemCode
{
    public override void DoComportament(MainInterface main, InventoryItem item)
    {
        int health = (int)(main.GetTotalLife() * 0.2f);

        main.AddActualLife(health);
        main.CreateNewNotification(
            $"Flor da Copa de Sangue: Voce cura {health} de Vida",
            main.GetWorkNodeByEnum(MyEnum.Work.AkumaNoMi).GetBaseImage()
        );

        item.RemoveQuantity();
        main.UpdateInventory();
    }
}
