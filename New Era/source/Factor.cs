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
    [Export]
    private NodePath modApplyControlPath;
    [Export]
    private NodePath restButtonPath;

    [Export]
    private bool usesModApply;
    [Export]
    private bool usesRestButton;

    [Signal]
    public delegate void total_factor_changed(int value);
    [Signal]
    public delegate void actual_factor_changed(int value);

    int actualMod;
    private bool connectionsMadded;

    public override void _Ready()
    {
        actualMod = (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode(applyButtonPath).Connect("button_up", this, "_OnApplyButtonUp");
        GetNode<SpinBox>(applySpinPath).Value = defaultApplyValue;
        GetTree().CurrentScene.Connect("main_ready", this, "_OnMainReady");

        if (!usesModApply)
        {
            GetNode<Control>(modApplyControlPath).Visible = false;
        }

        if (!usesRestButton)
            GetNode<Control>(restButtonPath).Visible = false;
        else
            GetNode(restButtonPath).GetChild<Button>(0).Connect("button_up", this, "_OnRestButtonUp");
    }


    private void _OnMainReady()
    {
        if (connectionsMadded) return;

        GetNode(modSpinPath).Connect("value_changed", this, "_OnModSpinChanged");
        if (relatedAtributePath != null)
            GetNode(relatedAtributePath).Connect("atribute_changed", this, "_OnReleatedAtributeChanged");
        
        connectionsMadded = true;
    }


    private void _OnRestButtonUp()
    {
        GetActualSpin().Value += GetTotalSpin().Value/4;
        if (GetActualSpin().Value > GetTotalSpin().Value)
            GetActualSpin().Value = GetTotalSpin().Value;
    }


    private void _OnModSpinChanged(float value)
    {
        int modification = (int) value - actualMod;
        actualMod = (int) value;

        GetNode<SpinBox>(totalSpinPath).Value += modification;
        GetNode<SpinBox>(actualSpinPath).Value += modification;

        EmitSpinSignal(totalSpinPath, nameof(total_factor_changed));
        EmitSpinSignal(actualSpinPath, nameof(actual_factor_changed));
    }


    private void _OnReleatedAtributeChanged(int value)
    {
        int finalValue = (int)(value*relatedAtributeRelevance) + bonusInCalculus;
        finalValue += (int) GetNode<SpinBox>(modSpinPath).Value;
        GetNode<SpinBox>(totalSpinPath).Value = finalValue;

        EmitSpinSignal(totalSpinPath, nameof(total_factor_changed));
    }


    private void _OnApplyButtonUp()
    {
        int applyValue = GetStartValue();
        GetNode<SpinBox>(actualSpinPath).Value += applyValue;

        EmitSpinSignal(actualSpinPath, nameof(actual_factor_changed));
    }

    private int GetStartValue()
    {
        int baseMod  = (int) GetNode<SpinBox>(applySpinPath).Value;
        int guardMod = (int) GetNode(modApplyControlPath).GetChild<SpinBox>(1).Value;

        if (guardMod > 0)
        {
            if (baseMod > 0) return baseMod;
            else
            {
                if (guardMod + baseMod <= 0)
                    return baseMod + guardMod;
                return 0;
            }
        }
        return baseMod;
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

    public void SetActualMod(int value)
    {
        actualMod = value;
    }

    public SpinBox GetGuardSpin()
    {
        return GetNode(modApplyControlPath).GetChild<SpinBox>(1);
    }

}
