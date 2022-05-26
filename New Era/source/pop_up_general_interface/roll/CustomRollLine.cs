using Godot;
using System;

public class CustomRollLine : MarginContainer
{
    [Export]
    private NodePath baseColorPath;
    [Export]
    private NodePath rollButton;
    [Export]
    private NodePath firstLine;
    [Export]
    private NodePath diceLine;
    [Export]
    private NodePath sumLine;
    [Export]
    private NodePath resultLine;

    public override void _Ready()
    {
        GetNode(rollButton).Connect("button_up", this, nameof(_OnButtonUp));
    }

    private void _OnButtonUp()
    {
        int firstValue = (int) GetNode<SpinBox>(firstLine).Value;
        int diceValue = (int)GetNode<SpinBox>(diceLine).Value;
        int sumValue = (int)GetNode<SpinBox>(sumLine).Value;

        GetNode<LineEdit>(resultLine).Text =
            (RollCode.GetRandomCustomRoll(diceValue, firstValue) + sumValue).ToString();
    }


    public void SetSecondaryColor(Color color)
    {
    }

    public void SetPrincipalColor(Color color)
    {
        color.a8 = 150;
        GetNode<ColorRect>(baseColorPath).Color = color;
    }
}
