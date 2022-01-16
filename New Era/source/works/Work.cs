using Godot;
using System;

public abstract class Work : Node
{
    [Export]
    private string workName;
    [Export]
    private Texture baseImage;
    [Export(PropertyHint.MultilineText)]
    private string pathDescription;
    [Export]
    private PackedScene[] skills = { };
    [Export(PropertyHint.MultilineText)]
    private string description;
    [Export]
    private MyEnum.Work enumWork;
    [Export]
    private MyEnum.Atribute relationedAtribute;




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
}