using Godot;
using System;

public abstract class Skill : Node
{
    [Export]
    private string skillName;
    [Export]
    private CSharpScript wayOfLevelCalculeScript;

    public abstract void DoMechanic();
    private WayOfCalculeSkill wayOfLevelCalcule;

    public String GetSkillName()
    {
        return skillName;
    }

    public void PlayWayOfLevelCalcule(WorkTree workTree, int workIndex, int skillIndex, int level)
    {
        wayOfLevelCalcule = (WayOfCalculeSkill)wayOfLevelCalculeScript.New();
        wayOfLevelCalcule.CalculeLevelSkill(workTree, workIndex, skillIndex, level);
    }

}