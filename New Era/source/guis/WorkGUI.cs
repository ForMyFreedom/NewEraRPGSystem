using Godot;
using System;

public class WorkGUI : WindowDialog
{
    [Export]
    private PackedScene workPackedScene;
    [Export]
    private NodePath descriptionLabelPath;
    [Export]
    private NodePath rollBoxPath;

    private Work work;
    private int workLevel;


    public override void _Ready()
    {

        work = workPackedScene.Instance<Work>();
        WindowTitle = work.GetWorkName();

        GetNode<Label>(descriptionLabelPath).Text = work.GetDescription();
        GetNode(rollBoxPath).Connect("roll_maded", this, "_OnRollMaded");
        GetNode(rollBoxPath).Connect("value_changed", this, "_OnValueChanged");
    }


    private void _OnRollMaded(int result)
    {

    }

    private void _OnValueChanged(int value)
    {

    }





    public int GetLevelValue()
    {
        return workLevel;
    }

    public void SetLevelValue(int value)
    {
        workLevel = value;
    }
}
