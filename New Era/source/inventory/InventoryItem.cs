using Godot;
using System;

public abstract class InventoryItem: Resource
{
    [Export]
    protected string itemName;
    [Export]
    protected string itemDescription;
    [Export]
    protected int quantity;
    [Export]
    protected CSharpScript useCode;

    protected ItemCode itemCode;

    public void ActivateItem(MainInterface main)
    {
        if (useCode == null) return;
        itemCode = (ItemCode) useCode.New();
        itemCode.DoComportament(main, this);
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
