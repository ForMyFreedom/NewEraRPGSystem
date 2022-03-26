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
