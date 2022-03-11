using Godot;
using System;

using Statics.Enums;

public class AtributeOptionButton : OptionButton
{
    [Signal]
    public delegate void related_atribute_changed(int index);

    public override void _Ready()
    {
        Connect("item_selected", this, "_OnItemSelected");
    }

    private void _OnItemSelected(int index)
    {
        SetAtribute(index);
        EmitSignal(nameof(related_atribute_changed), index);
    }


    public void SetAtribute(MyEnum.Atribute atr)
    {
        SetAtribute((int) atr);
    }

    public void SetAtribute(int index)
    {
        Select(index);
    }
}
