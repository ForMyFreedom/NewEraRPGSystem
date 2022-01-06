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
    [Export]
    private NodePath applySpinPath;
    [Export]
    private NodePath applyButtonPath;

    int actualMod;


    public override void _Ready()
    {
        actualMod = (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode(modSpinPath).Connect("value_changed", this, "_OnModSpinChanged");
        GetNode(applyButtonPath).Connect("button_up", this, "_OnApplyButtonUp");

        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
    }


    private void _OnTreeReady()
    {
        GetNode(modSpinPath).Connect("value_changed", this, "_OnModSpinChanged");
        
        if (relatedAtributePath != null)
            GetNode(relatedAtributePath).Connect("ready", this, "_OnReleatedAtributeReady");
    }



    private void _OnModSpinChanged(float value)
    {
        int modification = (int)value - actualMod;
        GetNode<SpinBox>(totalSpinPath).Value += modification;
        GetNode<SpinBox>(actualSpinPath).Value += modification;
        actualMod = (int) value;
    }


    private void _OnRelatedAtributeChanged(int value)
    {
        int finalValue = (int)(value*relatedAtributeRelevance) + bonusInCalculus;
        finalValue += (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode<SpinBox>(totalSpinPath).Value = finalValue;
        GetNode<SpinBox>(actualSpinPath).Value = finalValue;
    }


    private void _OnApplyButtonUp()
    {
        int applyValue = (int) GetNode<SpinBox>(applySpinPath).Value;
        GetNode<SpinBox>(actualSpinPath).Value += applyValue;
    }




    public SpinBox GetActualSpin()
    {
        return GetNode<SpinBox>(actualSpinPath);
    }

    public SpinBox GetTotalSpin()
    {
        return GetNode<SpinBox>(totalSpinPath);
    }

    public SpinBox GetModSpin()
    {
        return GetNode<SpinBox>(modSpinPath);
    }
}
