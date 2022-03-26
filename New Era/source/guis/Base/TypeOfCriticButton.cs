using Godot;
using System;

public class TypeOfCriticButton : CheckBox
{
    public override void _Ready()
    {
        Connect("pressed", this, "_OnPressed");   
    }

    public void _OnPressed()
    {
        if (Pressed)
            Text = "DET";
        else
            Text = "MAX";
    }

    public bool GetCriticType()
    {
        return Pressed;
    }
}
