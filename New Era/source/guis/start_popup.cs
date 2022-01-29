using Godot;
using System;

public class start_popup : Control
{
    public override void _Ready()
    {
        Popup pop = GetChild<Popup>(0);
        pop.PopupCenteredRatio(0.5f);
    }

}
