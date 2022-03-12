using Godot;
using System;

using Entities.Interface;

public abstract class InventoryItem: Resource
{
    [Export]
    protected string itemName;
    [Export]
    protected string itemDescription;
    [Export]
    protected int quantity;
    [Export]
    protected Resource useCode;

    public void ActivateItem(MainInterface main)
    {
        if (useCode == null || quantity<=0) return;
        ItemCode itemCode = (ItemCode) useCode;
        itemCode.DoComportament(main, this);
    }

    public void RemoveQuantity(int quant = 1)
    {
        quantity -= quant;
    }


    public string GetItemName()
    {
        return itemName;
    }

    public void SetItemName(string name)
    {
        itemName = name;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    public void SetItemDescription(string desc)
    {
        itemDescription = desc;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void SetQuantity(int quant)
    {
        quantity = quant;
    }
}
