using Godot;
using System;

public class Atribute : Control
{
    [Export]
    public String atributeName;
    [Export]
    private NodePath nameLabelPath;
    [Export]
    private NodePath rollBoxPath;

    [Signal]
    public delegate void atribute_change(int value);


    public override void _Ready()
    {
        GetNode<Label>(nameLabelPath).Text = atributeName;
        GetNode<RollBox>(rollBoxPath).Connect("roll_maded", this, "_OnRollMaded");
        GetNode<RollBox>(rollBoxPath).Connect("value_changed", this, "_OnValueChanged");
    }


    private void _OnRollMaded(int result)
    {
        //emitsignal?
    }


    private void _OnValueChanged(int value)
    {
        EmitSignal(nameof(atribute_change), value);
    }




    public int GetAtributeValue()
    {
        return GetNode<RollBox>(rollBoxPath).GetRollValue();
    }

    public void SetAtributeValue(int value)
    {
        GetNode<RollBox>(rollBoxPath).SetRollValue(value);
    }

    public int GetModValue()
    {
        return GetNode<RollBox>(rollBoxPath).GetModValue();
    }

    public void SetModValue(int value)
    {
        GetNode<RollBox>(rollBoxPath).SetModValue(value);
    }

}
