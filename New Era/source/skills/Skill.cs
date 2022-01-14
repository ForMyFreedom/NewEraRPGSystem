using Godot;
using System;

public abstract class Skill : Node
{
    [Export]
    private string skillName;

    public abstract void DoMechanic();
    
    
    public String GetSkillName()
    {
        return skillName;
    }

}