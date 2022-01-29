using Godot;
using System;

public class MechanicButton : Button
{
    [Signal]
    public delegate void do_mechanic(int index);

    public override void _Ready()
    {
        Connect("button_up", this, "_OnButtonUp");
    }

    private void _OnButtonUp()
    {
        EmitSignal(nameof(do_mechanic), GetIndex());
    }
}
