using Godot;
using System;

public class CriticRegulatorBox : HBoxContainer
{
    [Export]
    private NodePath criticLimitSpinBoxPath;
    [Export]
    private NodePath typeOfCriticLimitButtonPath;



    public override void _Ready()
    {
        GetNode(typeOfCriticLimitButtonPath).Connect(
            nameof(TypeOfCriticButton.style_changed), this, "_OnStyleChanged"
        );
    }


    private void _OnStyleChanged(bool state)
    {
        GetNode<SpinBox>(criticLimitSpinBoxPath).Editable = state;
    }



    public int GetCriticLimitLevel()
    {
        return (int) GetNode<SpinBox>(criticLimitSpinBoxPath).Value;
    }

    public bool IsCriticLimited()
    {
        return GetNode<TypeOfCriticButton>(typeOfCriticLimitButtonPath).GetCriticType();
    }
}
