using Godot;
using System;

public class WorkGUI : WindowDialog
{
    [Export]
    private NodePath descriptionLabelPath;
    [Export]
    private NodePath rollBoxPath;
    [Export]
    private NodePath workTexture;
    [Export]
    private NodePath journeyLabel;

    [Signal]
    public delegate void value_changed(int index, int value);

    private Work work = null;
    private int workIndex;
    
    private Atributo relatedAtribute;

    public override void _Ready()
    {
        WindowTitle = work.GetWorkName();

        GetNode<Label>(descriptionLabelPath).Text = work.GetDescription();
        GetNode<TextureRect>(workTexture).Texture = work.GetBaseImage();
        relatedAtribute = GetInterfaceAtributeByEnum(work.GetRelationedAtribute());
        PassDataToRollBox();

        GetNode(rollBoxPath).Connect("roll_maded", this, "_OnRollMaded");
        GetNode(rollBoxPath).Connect("value_changed", this, "_OnValueChanged");
        Connect("popup_hide", this, "_OnPopupHide");
    }

    private void PassDataToRollBox()
    {
        GetNode<RollBox>(rollBoxPath).SetRelationedSum(relatedAtribute, "atribute_changed");
        GetNode<RollBox>(rollBoxPath).SetSumValue(relatedAtribute.GetAtributeValue());
    }


    private void _OnRollMaded(int result)
    {
        //@
    }

    private void _OnValueChanged(int value)
    {
        EmitSignal(nameof(value_changed), workIndex, value);
    }


    public void ConnectAllSignals(WorkTree main)
    {
        Connect(nameof(value_changed), main, nameof(main._OnWorkValueChanged));
    }


    private void _OnPopupHide()
    {
        QueueFree();
    }




    public void PopupIt()
    {
        PopupCenteredRatio(0.5f);
    } 

    public void SetWork(Work w)
    {
        work = w;
        GetNode<RichTextLabel>(journeyLabel).BbcodeText += work.GetPathDescription();
    }

    public int GetWorkIndex()
    {
        return workIndex;
    }

    public void SetWorkIndex(int index)
    {
        workIndex = index;
    }


    public int GetLevelValue()
    {
        return GetNode<RollBox>(rollBoxPath).GetRollValue();
    }

    public void SetLevelValue(int value)
    {
        GetNode<RollBox>(rollBoxPath).SetRollValue(value);
    }
}
