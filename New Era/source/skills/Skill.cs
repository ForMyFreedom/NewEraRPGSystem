using Godot;
using System;

public abstract class Skill : Resource
{
    [Export]
    private string skillName;
    [Export]
    private CSharpScript wayOfLevelCalculeScript;
    [Export]
    private String skillDescription;
    [Export]
    private int level;

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


    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int l)
    {
        level = l;
    }

    public void AddLevel(int add)
    {
        level += add;
    }


    public String GetSkillDescription()
    {
        return skillDescription;
    }

    public void SetSkillDescription(String str)
    {
        skillDescription = str;
    }
}