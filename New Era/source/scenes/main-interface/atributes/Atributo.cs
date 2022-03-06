using Godot;
using System;

public class Atributo : Control
{
    [Export]
    public String atributeName;
    [Export]
    private NodePath nameLabelPath;
    [Export]
    private NodePath rollBoxPath;

    [Signal]
    public delegate void atribute_changed(int value);


    public override void _Ready()
    {
        GetNode<Label>(nameLabelPath).Text = atributeName;
        GetNode<RollBox>(rollBoxPath).Connect("roll_maded", this, "_OnRollMaded");
        GetNode<RollBox>(rollBoxPath).Connect("value_changed", this, "_OnValueChanged");
        GetNode<RollBox>(rollBoxPath).Connect("mod_changed", this, "_OnValueChanged");
        
        GetNode<RollBox>(rollBoxPath).SetRelationedSum(this, nameof(atribute_changed));
    }


    private void _OnRollMaded(int result)
    {
        //emitsignal?@
    }


    private void _OnValueChanged(int value)
    {
        EmitSignal(nameof(atribute_changed), GetTotalValue());
    }


    public int RequestRoll(int modValue=0)
    {
        return GetNode<RollBox>(rollBoxPath).GetRandomRoll(modValue);
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


    private int GetTotalValue()
    {
        return GetNode<RollBox>(rollBoxPath).GetModValue() + GetNode<RollBox>(rollBoxPath).GetRollValue();
    }
}
