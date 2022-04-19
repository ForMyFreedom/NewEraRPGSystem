using Godot;
using System;

public abstract class GeneralButton : Button
{
    [Export]
    private PackedScene packedPopup;

    protected MyPopup myPopup;
    protected Node baseDataNode;

    public override void _Ready()
    {
        if (GetChildren().Count>0)
            baseDataNode = GetChild(0);
    }

    public void CreatePopup(Control main)
    {
        if (baseDataNode == null) return;
        myPopup = packedPopup.Instance<MyPopup>();
        main.AddChild(myPopup);
        myPopup.InjectDataNode(baseDataNode);
        myPopup.PopupIt();
    }
}
