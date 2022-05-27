using Godot;
using System;

public class CustomRollData : Node
{
    private Color principalColor;
    private Color secondaryColor;

    public Color GetPrincipalColor()
    {
        return principalColor;
    }

    public void SetPrincipalColor(Color color)
    {
        principalColor = color;
    }

    public Color GetSecondaryColor()
    {
        return secondaryColor;
    }

    public void SetSecondaryColor(Color color)
    {
        secondaryColor = color;
    }
}
