using Godot;

public class SkillCriticEntity : CriticEntity
{
    [Export]
    private string skillName;

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestSkillRoll(skillName) / 10;
    }
}
