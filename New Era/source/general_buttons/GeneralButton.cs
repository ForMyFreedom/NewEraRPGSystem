using Godot;
using System;

public abstract class GeneralButton : Button
{
    [Export]
    private PackedScene packedPopup;

    protected MyPopup myPopup;

    public void CreatePopup(Control main)
    {
        myPopup = packedPopup.Instance<MyPopup>();
        myPopup.SetMain(main);
        PassDataToPopup();
        main.AddChild(myPopup);
        myPopup.PopupIt();
    }

    public abstract void PassDataToPopup();
    public abstract void SetData(object[] data);
    public abstract object GetData();
}
