using Godot;
using System;

public abstract class Work : Node
{
    [Export]
    private Texture baseImage;
    [Export]
    private PackedScene[] skills = { };


    public abstract String GetWorkName();

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
}