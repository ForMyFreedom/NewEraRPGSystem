using Godot;
using System;

public class SkillGUI : BaseGUI
{
    private Skill skill;
    private int skillLevel;
    private int skillIndex;
    private int workIndex;

    [Signal]
    public delegate void value_changed(int workindex, int skillIndex, int value);

    public override void _Ready()
    {
        base._Ready();
        WindowTitle = skill.GetSkillName();
        GetNode<Label>(descriptionLabelPath).Text = work.GetSkillDescription()[skillIndex];
    }

    protected override void _OnRollMaded(int result)
    {
        //@
    }

    protected void _OnRelatedAtributeChanged(int index)
    {
        //@
    }

    protected override void _OnValueChanged(int value)
    {
        EmitSignal(nameof(value_changed), workIndex, skillIndex, value);
    }


    public void ConnectAllSignals(WorkTree father)
    {
        Connect(nameof(value_changed), father, nameof(father._OnSkillValueChanged));
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
        GetNode<RollBox>(rollBoxPath).SetRollValue(skillLevel);
    }

    public void SetWork(Work w)
    {
        work = w;
    }

    public void SetSkillIndex(int i)
    {
        skillIndex = i;
    }

    public void SetWorkIndex(int i)
    {
        workIndex = i;
    }
}
