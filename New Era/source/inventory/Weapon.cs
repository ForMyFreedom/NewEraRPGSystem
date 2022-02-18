using Godot;
using System;

public abstract class Weapon: InventoryItem
{
    [Export]
    private int damage;


    public int GetDamage()
    {
        return damage;
    }
}
