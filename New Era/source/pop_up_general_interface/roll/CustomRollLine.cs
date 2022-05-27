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
    [Export]
    private NodePath rollSFXPlayerPath;

    public override void _Ready()
    {
        GetNode(rollButton).Connect("button_up", this, nameof(_OnRoll));
    }

    private void _OnRoll()
    {
        int firstValue = (int) GetNode<SpinBox>(firstLine).Value;
        int diceValue = (int)GetNode<SpinBox>(diceLine).Value;
        int sumValue = (int)GetNode<SpinBox>(sumLine).Value;

        GetNode<LineEdit>(resultLine).Text =
            (RollCode.GetRandomCustomRoll(diceValue, firstValue) + sumValue).ToString();

        GetNode<MultipleStreamPlayer>(rollSFXPlayerPath).PlayRandomAudio();
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
