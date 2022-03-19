using Godot;
using System;

public abstract class BombaFumaca : ItemCode
{
    [Export(PropertyHint.MultilineText)]
    private string message;
    [Export]
    private Texture bombTexture;

    public override void DoComportament(MainInterface main, InventoryItem item)
    {
        main.CreateNewNotification(message, bombTexture);

        item.RemoveQuantity();
        main.UpdateInventory();
    }
}
