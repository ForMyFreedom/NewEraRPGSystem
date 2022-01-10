using Godot;
using System;

public abstract class MyPopup : WindowDialog
{
    [Export]
    protected float RATIO = 0.7f;

    protected MainInterface main;



    public override void _Ready()
    {
        Connect("popup_hide", this, "_OnPopupHide");
    }


    protected void _OnPopupHide()
    {
        PassDataToMain();
    }


    public abstract void PopupIt();
    public abstract void PassDataToMain();


    public void SetMain(Control control)
    {
        main = (MainInterface) control;
    }
}
