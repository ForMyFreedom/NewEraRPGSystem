using Godot;
using System;

public abstract class ItemCode : Resource
{
    public abstract void DoComportament(MainInterface main, InventoryItem item);
}
