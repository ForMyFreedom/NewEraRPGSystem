using Godot;
using System;

public class CriticRegulatorBox : HBoxContainer
{
    [Export]
    private NodePath criticLimitSpinBoxPath;

    private bool isLimited = false;


    public override void _Ready()
    {
        GetNode(criticLimitSpinBoxPath).Connect("value_changed", this, "_OnCriticLimitChanged");
    }


    private void _OnCriticLimitChanged(float value)
    {
        if (value > 0)
            isLimited = true;
        else
            isLimited = false;
    }



    public int GetCriticLimitLevel()
    {
        return (int) GetNode<SpinBox>(criticLimitSpinBoxPath).Value;
    }

    public bool IsCriticLimited()
    {
        return isLimited;
    }
}
