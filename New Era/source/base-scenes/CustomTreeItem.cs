using Godot;
using Godot.Collections;
using System;

public class CustomTreeItem : Control
{
    [Export]
    private PackedScene itemPackedScene;
    [Export]
    private NodePath boxPath;

    public Control CreateNewItem(Dictionary<string,object> data)
    {
        Control newItem = (Control) itemPackedScene.Instance();
        SetAllData(data, newItem);
        GetNode<Control>(boxPath).AddChild(newItem);
        return newItem;
    }


    public void UpdateItem(int index, Dictionary<string, object> data)
    {
        SetAllData(data, GetNode(boxPath).GetChild<Control>(index));
        GetNode(boxPath).GetChild(index)._Ready();
    }


    private void SetAllData(Dictionary<string,object> data, Control item)
    {
        foreach (string key in data.Keys)
            item.SetMeta(key, data[key]);
    }
}
