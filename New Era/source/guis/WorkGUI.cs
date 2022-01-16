using Godot;
using Godot.Collections;
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
    private Array<int> worksUps;
    private int lastWorkValue;

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
        VerifyTheMaestryPath(value);
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

    private Atributo GetInterfaceAtributeByEnum(MyEnum.Atribute atribute)
    {
        MainInterface main = (MainInterface) GetTree().CurrentScene;
        return main.GetAtributeNodeByEnum(atribute);
    }


    private void VerifyTheMaestryPath(int value) //@ what about lose work? [maybe cant lose]
                                                 //@ what about pass workup when close?
    {
        Array<int> newWorkUps = CalculeWorkUps(value);
        Array<int> difWorkUps = GetDifferenceFromArrays(newWorkUps, worksUps);
        DoWorkUps(difWorkUps);

    }

    private Array<int> CalculeWorkUps(int value)
    {
        Array<int> workUps = new Array<int>();
        int[] upProgression = new[] { 5, 10, 50 }; //@
        for(int i = 0; i < 3; i++)
        {
            int currentValue = value;
            while (currentValue >= upProgression[i])
            {
                currentValue -= upProgression[i];
                worksUps[i]++;
            }
        }

        return worksUps;
    }


    private Array<int> GetDifferenceFromArrays(Array<int> array1, Array<int> array2)
    {
        Array<int> difArray = new Array<int>();
        
        for(int i = 0; i < 3; i++)
        {
            difArray[i] = array1[i];
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
