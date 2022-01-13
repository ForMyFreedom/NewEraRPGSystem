using Godot;
using System;

public class filhodaputa : Control
{
    public override void _Ready()
    {
        Popup pop = GetChild<Popup>(0);
        pop.PopupCenteredRatio(0.5f);
    }

}
