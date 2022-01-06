using Godot;
using System;

public abstract class Work : Godot.Object
{
    private Skill[] skillList;



    public Skill[] GetSkillList()
    {
        return skillList;
    }
}