using Godot;
using System;

using Entities;

public abstract class ItemCode : Resource
{
    public abstract void DoComportament(MainInterface main, InventoryItem item);
}
