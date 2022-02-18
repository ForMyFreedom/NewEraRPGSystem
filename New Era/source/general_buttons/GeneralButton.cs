using Godot;
using System;

public abstract class GeneralButton : Button
{
    [Export]
    private PackedScene packedPopup;

    protected MyPopup myPopup;
    protected Node baseData;

    public override void _Ready()
    {
        if (GetChildren().Count>0)
            baseData = GetChild(0);
    }

    public void CreatePopup(Control main)
    {
        if (baseData == null) return;
        myPopup = packedPopup.Instance<MyPopup>();
        main.AddChild(myPopup);
        myPopup.InjectData(baseData);
        myPopup.PopupIt();
    }
}
