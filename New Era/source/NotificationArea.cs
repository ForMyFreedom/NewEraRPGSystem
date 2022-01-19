using Godot;
using System;

public class NotificationArea : Control
{
    [Export]
    private NodePath bellPath;
    [Export]
    private NodePath animationPath;

    private bool toShow = false;

    public override void _Ready()
    {
        GetNode(bellPath).Connect("gui_input", this, "_OnBellGuiInput");
    }


    private void _OnBellGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton buttonEvent = (InputEventMouseButton) @event;
        if (buttonEvent.ButtonIndex != (int) ButtonList.Left) return;

        if (buttonEvent.Pressed)
        {
            toShow = !toShow;
        }else return;

        if (toShow)
            GetNode<AnimationPlayer>(animationPath).Play("show");
        else
            GetNode<AnimationPlayer>(animationPath).Play("dishow");
    }
}
