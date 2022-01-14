 using Godot;
using System;

public class RollBox : VBoxContainer
{
    [Export]
    private NodePath rollButtonPath;
    [Export]
    private NodePath spinValuePath;
    [Export]
    private NodePath modSpinPath;
    [Export]
    private NodePath resultLabelPath;
    [Export]
    private NodePath criticLabelPath;

    private Random rgn;

    [Signal]
    public delegate void roll_maded(int result);

    [Signal]
    public delegate void value_changed(int value);


    public override void _Ready()
    {
        rgn = new Random();
        GetNode(rollButtonPath).Connect("button_up", this, "_OnRoll");
        GetNode(spinValuePath).Connect("value_changed", this, "_OnRollValueChanged");
    }


    private void _OnRoll()
    {
        int result = GetRandomRoll(GetRollValue() + GetModValue());
        ChangeLabels(result);
        EmitSignal(nameof(roll_maded), result); 
    }


    private void _OnRollValueChanged(float value)
    {
        EmitSignal(nameof(value_changed), value);
    }


    private void ChangeLabels(int result)
    {
        GetNode<Label>(resultLabelPath).Text = result.ToString();
        GetNode<Label>(criticLabelPath).Text = (result / 10).ToString() + " Criticos";
    }



    private int GetRandomRoll(int value)
    {
        int sum = value;
        int effect = (value > 0) ? 1 : -1;

        for (int i = 0; i < Math.Abs(value); i++)
            sum += rgn.Next(1, 7) * effect;

        return sum;
    }

    private int GetValueFromSpin(NodePath path)
    {
        return (int) GetNode<SpinBox>(path).Value;
    }



    public int GetRollValue()
    {
        return GetValueFromSpin(spinValuePath);
    }

    public void SetRollValue(int value)
    {
        GetNode<SpinBox>(spinValuePath).Value = value;
    }


    public int GetModValue()
    {
        return GetValueFromSpin(modSpinPath);
    }

    public void SetModValue(int value)
    {
        GetNode<SpinBox>(modSpinPath).Value = value;
    }

}
