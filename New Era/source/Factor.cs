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
    public double defaultApplyValue;

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

    [Signal]
    public delegate void total_factor_change(int value);
    [Signal]
    public delegate void actual_factor_change(int value);

    int actualMod;


    public override void _Ready()
    {
        actualMod = (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode(applyButtonPath).Connect("button_up", this, "_OnApplyButtonUp");
        GetNode<SpinBox>(applySpinPath).Value = defaultApplyValue;
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
    }


    private void _OnTreeReady()
    {
        GetNode(modSpinPath).Connect("value_changed", this, "_OnModSpinChanged");

        if (relatedAtributePath != null)
        {
            GetNode(relatedAtributePath).Connect("atribute_change", this, "_OnReleatedAtributeChanged");
        }
    }



    private void _OnModSpinChanged(float value)
    {
        int modification = (int) value - actualMod;
        actualMod = (int) value;

        GetNode<SpinBox>(totalSpinPath).Value += modification;
        GetNode<SpinBox>(actualSpinPath).Value += modification;

        EmitSpinSignal(totalSpinPath, nameof(total_factor_change));
        EmitSpinSignal(actualSpinPath, nameof(actual_factor_change));
    }


    private void _OnReleatedAtributeChanged(int value)
    {
        int finalValue = (int)(value*relatedAtributeRelevance) + bonusInCalculus;
        finalValue += (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode<SpinBox>(totalSpinPath).Value = finalValue;

        EmitSpinSignal(totalSpinPath, nameof(total_factor_change));
    }


    private void _OnApplyButtonUp()
    {
        int applyValue = (int) GetNode<SpinBox>(applySpinPath).Value;
        GetNode<SpinBox>(actualSpinPath).Value += applyValue;

        EmitSpinSignal(actualSpinPath, nameof(actual_factor_change));
    }



    private void EmitSpinSignal(NodePath path, String signal)
    {
        EmitSignal(signal, GetNode<SpinBox>(path).Value);
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
