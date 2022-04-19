using Godot;
using System;

public class BombaFumaca : ItemCode
{
    [Export]
    private Texture bombTexture;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        item.RemoveQuantity();
        main.UpdateInventory();

        return new MessageNotificationData(
            message, null, bombTexture
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
