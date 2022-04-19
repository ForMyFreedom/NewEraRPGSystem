using Godot;
using Godot.Collections;
using System;

public class InventoryPopup : MyPopup
{
    [Export]
    private NodePath inventoryListPath;

    private CharacterInventory inventory;
    private Array<InventoryItem> itens;

    public override void InjectDataNode(Node baseData)
    {
        inventory = (CharacterInventory) baseData;
        itens = ((CharacterInventory) baseData).GetItens();
    }


    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
        DoReady();
    }


    public void DoReady()
    {
        CustomTreeItem itemList = GetNode<CustomTreeItem>(inventoryListPath);

        foreach(InventoryItem item in itens)
        {
            Control newItem = itemList.CreateNewItem(GetTextData(item));
            newItem.Connect("item_activated", this, "_OnItemActivated");
            newItem.Connect("quant_modified", this, "_OnQuantModified");
            newItem.Connect("name_modified", this, "_OnNameModified");
            newItem.Connect("desc_modified", this, "_OnDescModified");
        }
    }


    public void UpdateItensText()
    {
        CustomTreeItem itemList = GetNode<CustomTreeItem>(inventoryListPath);

        for(int i = 0; i < itens.Count; i++)
        {
            itemList.UpdateItem(i, GetTextData(itens[i]));
        }
    }

    private void _OnItemActivated(int index)
    {
        itens[index].ActivateItem(GetMain());
    }

    private void _OnQuantModified(int quant, int index)
    {
        itens[index].SetQuantity(quant);
    }

    private void _OnNameModified(string name, int index)
    {
        itens[index].SetItemName(name);
    }

    private void _OnDescModified(string desc, int index)
    {
        itens[index].SetItemDescription(desc);
    }



    private Dictionary<string,object> GetTextData(InventoryItem item)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["_quant"] = item.GetQuantity().ToString();
        data["_name"]  = item.GetItemName();
        data["_desc"]  = item.GetItemDescription();

        return data;
    }



}
