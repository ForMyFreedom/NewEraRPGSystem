
public class SameOfWorkWayOfCalculeSkill : WayOfCalculeSkill
{
    public override void CalculeLevelSkill(WorkTree workTree, int workIndex, int skillIndex, int level)
    {
        workTree.SetAnSkillLevel(workIndex, skillIndex, level);
    }
}