using Godot;
using System;

public class TypeOfCriticButton : CheckBox
{
    [Signal]
    public delegate void style_changed(bool state);

    public override void _Ready()
    {
        Connect("pressed", this, "_OnPressed");   
    }

    public void _OnPressed()
    {
        if (Pressed)
            Text = "MAX";
        else
            Text = "---";

        EmitSignal(nameof(style_changed), Pressed);
    }

    public bool GetCriticType()
    {
        return Pressed;
    }
}
