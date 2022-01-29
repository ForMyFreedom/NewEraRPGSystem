using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class Work : Resource
{
    [Export]
    protected string workName;
    [Export]
    protected Texture baseImage;
    [Export(PropertyHint.MultilineText)]
    protected string pathDescription;
    [Export]
    protected Skill[] skills = { };
    [Export(PropertyHint.MultilineText)]
    protected string description;
    [Export]
    protected MyEnum.Work enumWork;
    [Export]
    protected MyEnum.Atribute relationedAtribute;
    [Export]
    private int level;
    [Export]
    private Array<int> worksUps;


    public abstract void DoFirstUpStep(MainInterface gui);
    public abstract void DoSecondUpStep(MainInterface gui);
    public abstract void DoThirdUpStep(MainInterface gui);



    public String GetWorkName()
    {
        return workName;
    }

    public Texture GetBaseImage()
    {
        return baseImage;
    }

    public Skill[] GetSkillList()
    {
        return skills;
    }

    public string GetDescription()
    {
        return description;
    }

    public MyEnum.Work GetEnumWork()
    {
        return enumWork;
    }

    public string GetPathDescription()
    {
        return pathDescription;
    }
    
    public MyEnum.Atribute GetRelationedAtribute()
    {
        return relationedAtribute;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int l)
    {
        level = l;
    }

    public Array<int> GetWorksUp()
    {
        return worksUps;
    }

    public void SetWorksUp(Array<int> wu)
    {
        worksUps = wu;
    }

    protected String GetCreatePowerMessage()
    {
        return "Voce precisa criar um uso de critico ou tecnica";
    }

}