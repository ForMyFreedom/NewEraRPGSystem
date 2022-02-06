using Godot;
using Godot.Collections;
using System;

public abstract class CriticUse : Resource
{
    [Export]
    protected String criticUseName;
    [Export]
    protected MyEnum.Work relatedWork;
    [Export]
    protected String text;
    [Export]
    protected int cost; //-1 -> N
    
    public abstract void DoMechanic(MainInterface main, int actionIndex=0, int critic = -1);
    public abstract void DoEndMechanicLogic();

    public void DoEndMechanic(object obj)
    {
        if (this != obj) return;
        DoEndMechanicLogic();
    }


    protected MainInterface main;
    protected Work injectedWork;


    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }



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

    public void InjectWork(Work w)
    {
        injectedWork = w;
    }
}
