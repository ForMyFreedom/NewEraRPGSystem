using Godot;
using System;

public abstract class ItemCode : Godot.Object
{
    public abstract void DoComportament(MainInterface main, InventoryItem item);
}
