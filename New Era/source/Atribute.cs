using Godot;
using System;

public class Atribute : Control
{
    [Export]
    public String atributeName;
    [Export]
    public int atributeValue;

    [Export]
    private NodePath nameLabelPath;
    [Export]
    private NodePath rollButtonPath;
    [Export]
    private NodePath spinValuePath;
    [Export]
    private NodePath resultLabelPath;
    [Export]
    private NodePath criticLabelPath;
    [Export]
    private NodePath modSpinPath;

    [Signal]
    public delegate void atribute_change(int value);

    private Random rgn;

    public override void _Ready()
    {
        rgn = new Random();

        GetNode<Label>(nameLabelPath).Text = atributeName;
        GetNode<SpinBox>(spinValuePath).Value = atributeValue;
        GetNode(rollButtonPath).Connect("button_up", this, "_OnRoll");
        GetNode(spinValuePath).Connect("value_changed", this, "_OnAtributeChanged");
    }


    private void _OnRoll()
    {
        int value = atributeValue + (int) GetNode<SpinBox>(modSpinPath).Value;
        int result = GetRandomRoll(value);

        GetNode<Label>(resultLabelPath).Text = result.ToString();
        GetNode<Label>(criticLabelPath).Text = (result / 10).ToString()+" Criticos";
    }




    private int GetRandomRoll(int value)
    {
        int sum = value;
        int effect = (value > 0) ? 1 : -1;

        for (int i = 0; i < Math.Abs(value); i++)
            sum+=rgn.Next(1, 7)*effect;

        return sum;
    }


    private void _OnAtributeChanged(float value)
    {
        atributeValue = (int) value;
        EmitSignal(nameof(atribute_change), new object[] { atributeValue });
    }
}
