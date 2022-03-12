using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities.Interface;
using Statics.Enums;

public abstract class BaseGUI : WindowDialog
{
    [Export]
    protected NodePath descriptionLabelPath;
    [Export]
    protected NodePath rollBoxPath;


    protected Atributo relatedAtribute;
    protected WorkInterface work;

    public override void _Ready()
    {
        relatedAtribute = GetInterfaceAtributeByEnum(work.GetRelationedAtribute());
        PassDataToRollBox();

        GetNode(rollBoxPath).Connect("roll_maded", this, "_OnRollMaded");
        GetNode(rollBoxPath).Connect("value_changed", this, "_OnValueChanged");
        Connect("popup_hide", this, "_OnPopupHide");
    }

    protected void PassDataToRollBox()
    {
        GetNode<RollBox>(rollBoxPath).SetRelationedSum(relatedAtribute, "atribute_changed");
        GetNode<RollBox>(rollBoxPath).SetSumValue(relatedAtribute.GetAtributeValue());
    }


    protected abstract void _OnRollMaded(int result);

    protected abstract void _OnValueChanged(int value);


    protected void _OnPopupHide()
    {
        QueueFree();
    }

    protected Atributo GetInterfaceAtributeByEnum(MyEnum.Atribute atribute)
    {
        MainInterface main = (MainInterface)GetTree().CurrentScene;
        return main.GetAtributeNodeByEnum(atribute);
    }

}