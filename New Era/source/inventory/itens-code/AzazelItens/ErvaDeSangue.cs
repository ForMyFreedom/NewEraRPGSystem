using Godot;
using System;

public class ErvaDeSangue : ItemCode
{
    [Export(PropertyHint.MultilineText)]
    private string message;
    [Export]
    private Texture image;

    public override void DoComportament(MainInterface main, InventoryItem item)
    {
        item.RemoveQuantity();
        main.UpdateInventory();

        int charismaImpact = -2*main.GetCharisma();
        int damage = (main.GetStrength() + main.GetAgility()) / 2;
        main.CreateNewNotification(
            MyStatic.GetNotificationText(message, charismaImpact, damage),
            image
        );
    }
}
