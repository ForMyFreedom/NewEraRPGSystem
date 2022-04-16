using Godot;
using Godot.Collections;
using System;
using System.Text.RegularExpressions;

public abstract class CriticUse : NotificationConsumer
{
    [Export]
    protected String criticUseName;
    [Export]
    protected MyEnum.Work relatedWork;
    [Export(PropertyHint.MultilineText)]
    protected String text;
    [Export(PropertyHint.MultilineText)]
    protected String baseMessage;
    [Export]
    protected int cost; //-1 -> N


    public CriticUse()
    {
        canLimit = (cost < 0);
    }

    protected Work injectedWork;

    public override abstract MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex=0, int critic = -1);
    public override abstract void DoEndMechanicLogic();
    public override abstract int RequestCriticTest(MainInterface main);

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
