using Godot;
using System;

public class Factor : Control
{
    [Export]
    public NodePath relatedAtributePath;
    [Export]
    public float relatedAtributeRelevance;
    [Export]
    public int bonusInCalculus;

    [Export]
    private NodePath totalSpinPath;
    [Export]
    private NodePath actualSpinPath;
    [Export]
    private NodePath modSpinPath;

    int actualMod;

    public override void _Ready()
    {
        actualMod = (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode(modSpinPath).Connect("value_changed", this, "_OnModSpinChanged");

        if (relatedAtributePath != null)
        {
            GetNode(relatedAtributePath).Connect("atribute_change", this, "_OnRelatedAtributeChanged");
        }
    }

    private void _OnModSpinChanged(float value)
    {
        int modification = (int)value - actualMod;
        GetNode<SpinBox>(totalSpinPath).Value += modification;
        GetNode<SpinBox>(actualSpinPath).Value += modification;
        actualMod = (int)value;
    }

    private void _OnRelatedAtributeChanged(int value)
    {
        int finalValue = (int)(value*relatedAtributeRelevance) + bonusInCalculus;
        finalValue += (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode<SpinBox>(totalSpinPath).Value = finalValue;
        GetNode<SpinBox>(actualSpinPath).Value = finalValue;
    }
}
