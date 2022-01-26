using Godot;
using Godot.Collections;
using System;

public abstract class Work : Node
{
    [Export]
    protected string workName;
    [Export]
    protected Texture baseImage;
    [Export(PropertyHint.MultilineText)]
    protected string pathDescription;
    [Export]
    protected PackedScene[] skills = { };
    [Export(PropertyHint.MultilineText)]
    protected string description;
    [Export]
    protected MyEnum.Work enumWork;
    [Export]
    protected MyEnum.Atribute relationedAtribute;
    [Export]
    protected Array<String> skillDescriptions;

    protected int level;
    protected Array<int> worksUps;


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
        Skill[] trueSkillList = new Skill[skills.Length];
        
        for(int i=0 ; i<skills.Length ; i++)
        {
            trueSkillList[i] = skills[i].Instance<Skill>();
        }

        return trueSkillList;
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

    public Array<string> GetSkillDescription()
    {
        return skillDescriptions;
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