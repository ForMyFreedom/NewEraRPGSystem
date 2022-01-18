using Godot;
using System;

public class SkillGUI : BaseGUI
{
    private Skill skill;
    private int skillLevel;
    private int skillIndex;


    public override void _Ready()
    {
        base._Ready();
        WindowTitle = skill.GetSkillName();
    }


    protected override void _OnRollMaded(int result)
    {
        //@
    }

    protected override void _OnValueChanged(int value)
    {
        //@
    }




    public void PopupIt()
    {
        PopupCenteredRatio(0.5f);
    }

    public void SetSkill(Skill s)
    {
        skill = s;
    }

    public void SetSkillLevel(int level)
    {
        skillLevel = level;
    }

    public void SetWork(Work w)
    {
        work = w;
    }

    public void SetSkillIndex(int i)
    {
        skillIndex = i;
    }

}
