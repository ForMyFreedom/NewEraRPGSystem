using Godot;
using System;

public abstract class MyPopup : WindowDialog
{
    [Export]
    protected float RATIO = 0.7f;

    public abstract void PopupIt();

    public abstract void InjectData(Node baseData);


    public MainInterface GetMain()
    {
        return (MainInterface) GetTree().CurrentScene;
    }
}
