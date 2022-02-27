using Godot;
using System;

public class PlayerSelectButton : Button
{
    [Signal]
    public delegate void select_player(int childIndex);

    public override void _Ready()
    {
        Connect("button_up", this, "_OnButtonUp");
    }


    private void _OnButtonUp()
    {
        EmitSignal(nameof(select_player), GetIndex());
    }
}
