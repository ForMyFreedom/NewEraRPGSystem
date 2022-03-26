using Godot;
using System;

public abstract class ItemCode : NotificationConsumer
{
    [Export(PropertyHint.MultilineText)]
    protected string message;

    protected InventoryItem item;

    public void DoComportament(MainInterface main, InventoryItem item)
    {
        this.item = item;
        DoMechanicLogic(main);
    }

    public abstract override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    public abstract override void DoEndMechanicLogic();
}
