using Godot;
using System;

public class SaveButton : TextureButton
{
    [Signal]
    public delegate void button_activate();

    public override void _Ready()
    {
        Connect("gui_input", this, "_OnGuiInput");
    }

    private void _OnGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick)
        {
            EmitSignal(nameof(button_activate));
            GetChild<AnimationPlayer>(0).Play("blink");
        }
    }
}
