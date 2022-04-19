using Godot;
using System;

public abstract class MyPopup : WindowDialog
{
    [Export]
    protected float RATIO = 0.7f;

    public abstract void PopupIt();

    public abstract void InjectDataNode(Node baseData);

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Esc"))
            Hide();
    }

    public MainInterface GetMain()
    {
        return (MainInterface) GetTree().CurrentScene;
    }
}
