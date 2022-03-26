using Godot;
using System;

public abstract class BombaFumaca : ItemCode
{
    [Export]
    private Texture bombTexture;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(message, bombTexture);

        item.RemoveQuantity();
        main.UpdateInventory();
    }

    public override void DoEndMechanicLogic()
    {
    }
}
