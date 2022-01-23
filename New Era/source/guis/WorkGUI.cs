using Godot;
using Godot.Collections;
using System;

public class WorkGUI : BaseGUI
{
    [Export]
    private NodePath workTexture;
    [Export]
    private NodePath journeyLabel;
    [Export]
    private NodePath atributeOptionPath;

    [Signal]
    public delegate void value_changed(int index, int value);

    private int workIndex;
    private Array<int> worksUps;
    private int lastWorkValue;

    public override void _Ready()
    {
        base._Ready();
        WindowTitle = work.GetWorkName();
        GetNode<AtributeOptionButton>(atributeOptionPath).SetAtribute(work.GetRelationedAtribute());

        GetNode<Label>(descriptionLabelPath).Text = work.GetDescription();
        GetNode<TextureRect>(workTexture).Texture = work.GetBaseImage();
        GetNode(atributeOptionPath).Connect("related_atribute_changed", this, "_OnRelatedAtributeChanged");
    }


    protected override void _OnRollMaded(int result)
    {
        //@
    }

    protected void _OnRelatedAtributeChanged(int index)
    {
        MainInterface main = (MainInterface) GetTree().CurrentScene;
        relatedAtribute = main.GetAtributeNodeByEnum((MyEnum.Atribute) index);
        PassDataToRollBox();
    }

    protected override void _OnValueChanged(int value)
    {
        VerifyTheMaestryPath(value);
        EmitSignal(nameof(value_changed), workIndex, value);
    }


    public void ConnectAllSignals(WorkTree main)
    {
        Connect(nameof(value_changed), main, nameof(main._OnWorkValueChanged));
    }



    private void VerifyTheMaestryPath(int value) //@ what about lose work? [maybe cant lose]
    {
        Array<int> newWorkUps = WorkUp.CalculeWorkUps(value);
        Array<int> difWorkUps = GetDifferenceFromArrays(newWorkUps, worksUps);
        DoWorkUps(difWorkUps);
        worksUps = newWorkUps;
    }


    private Array<int> GetDifferenceFromArrays(Array<int> array1, Array<int> array2)
    {
        Array<int> difArray = new Array<int>();
        
        for(int i = 0; i < 3; i++)
        {
            difArray.Add(array1[i]);
            difArray[i] -= array2[i];
        }

        return difArray;
    }

    private void DoWorkUps(Array<int> ups)
    {
        MainInterface main = (MainInterface) GetTree().CurrentScene;

        for(int i = 0; i < ups[0]; i++)
        {
            work.DoFirstUpStep(main);
        }

        for (int i = 0; i < ups[1]; i++)
        {
            work.DoSecondUpStep(main);
        }

        for (int i = 0; i < ups[2]; i++)
        {
            work.DoThirdUpStep(main);
        }
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
        lastWorkValue = value;
        GetNode<RollBox>(rollBoxPath).SetRollValue(value);
    }

    public Array<int> GetWorksUps()
    {
        return worksUps;
    }

    public void SetWorksUps(Array<int> value)
    {
        worksUps = value;
    }
}
