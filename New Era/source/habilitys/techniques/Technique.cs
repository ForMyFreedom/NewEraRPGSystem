using Godot;
using Godot.Collections;
using System;

public abstract class Technique : NotificationConsumer
{
    [Export]
    protected String techniqueName;
    [Export]
    protected MyEnum.Work[] relatedWorks;
    [Export]
    protected CriticUse[] criticUses;
    [Export]
    protected int[] powerOfCritics;
    [Export]
    protected int[] actionIndexOfCritics;
    [Export]
    protected int ofensiveLevel;
    [Export]
    protected int suportLevel;
    [Export]
    protected int level;

    protected Work[] injectedWorks;

    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        foreach(CriticUse use in criticUses)
        {
            //@
        }
    }


    public override void DoEndMechanicLogic() { }


    public String GetTechniqueName()
    {
        return techniqueName;
    }

    public MyEnum.Work[] GetRelatedWorks()
    {
        return relatedWorks;
    }

    public CriticUse[] GetCriticUses()
    {
        return criticUses;
    }

    public int[] GetPowerOfCritics()
    {
        return powerOfCritics;
    }

    public int[] GetActionIndexOfCritics()
    {
        return actionIndexOfCritics;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetOfensiveLevel()
    {
        return ofensiveLevel;
    }

    public int GetSuportLevel()
    {
        return suportLevel;
    }

    public void InjectWorks(Work[] ws)
    {
        injectedWorks = ws;
    }
}
