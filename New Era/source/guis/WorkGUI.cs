using Godot;
using System;

public class WorkGUI : WindowDialog
{
    [Export]
    private PackedScene workPackedScene;
    [Export]
    private NodePath descriptionLabelPath;
    [Export]
    private NodePath valueSpinPath;

    private Work work;
    private int[,] worksLevel;


    public override void _Ready()
    {

        work = workPackedScene.Instance<Work>();
        WindowTitle = work.GetWorkName();

        GetNode<Label>(descriptionLabelPath).Text = work.GetDescription();
        GetNode<SpinBox>(valueSpinPath).Value = 
    }
}
