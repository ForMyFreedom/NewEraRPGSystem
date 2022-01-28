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

    private int diceValue = 0;
    private int sumValue = 0;
    private int modValue = 0;

    [Signal]
    public delegate void roll_maded(int result);

    [Signal]
    public delegate void value_changed(int value);


    public override void _Ready()
    {
        GetNode(rollButtonPath).Connect("button_up", this, "_OnRoll");
        GetNode(spinValuePath).Connect("value_changed", this, "_OnRollValueChanged");
        GetNode(modSpinPath).Connect("value_changed", this, "_OnModValueChanged");
    }


    private void _OnRoll()
    {
        int result = RollCode.GetRandomAdvancedRoll(diceValue,sumValue,modValue);
        ChangeLabels(result);
        EmitSignal(nameof(roll_maded), result); 
    }


    private void _OnRollValueChanged(float value)
    {
        diceValue = (int) value;
        EmitSignal(nameof(value_changed), (int) value);
    }

    private void _OnModValueChanged(float value)
    {
        modValue = (int) value;
    }

    private void _OnSumValueChanged(float value)
    {
        sumValue = (int) value;
    }


    private void ChangeLabels(int result)
    {
        GetNode<Label>(resultLabelPath).Text = result.ToString();
        GetNode<Label>(criticLabelPath).Text = (result / 10).ToString() + " Criticos";
    }



    private int GetValueFromSpin(NodePath path)
    {
        return (int) GetNode<SpinBox>(path).Value;
    }



    public void SetRelationedSum(Node node, String signalName)
    {
        node.Connect(signalName, this, "_OnSumValueChanged");
    }


    public int GetRollValue()
    {
        return diceValue;
    }

    public void SetRollValue(int value)
    {
        diceValue = value;
        GetNode<SpinBox>(spinValuePath).Value = value;
    }


    public int GetSumValue()
    {
        return sumValue;
    }

    public void SetSumValue(int value)
    {
        sumValue = value;
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
