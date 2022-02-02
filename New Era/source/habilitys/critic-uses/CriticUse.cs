using Godot;
using Godot.Collections;
using System;

public abstract class CriticUse : Resource
{
    [Export]
    private String criticUseName;
    [Export]
    private MyEnum.Work relatedWork;
    [Export]
    private String text;
    [Export]
    private int cost; //-1 -> N
    
    public abstract void DoMechanic(MainInterface main, int actionIndex=0);





    public String GetUseName()
    {
        return criticUseName;
    }

    public MyEnum.Work GetRelatedWork()
    {
        return relatedWork;
    }
    
    public String GetText()
    {
        return text;
    }

    public int GetCost()
    {
        return cost;
    }
}
