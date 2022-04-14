using Godot;

public class SkillPlayerData : Resource, IVolatilePlayerData
{
    [Export]
    private MyEnum.Work workEnum;
    [Export]
    private int level;

    public MyEnum.Work GetWorkEnum()
    {
        return workEnum;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int value)
    {
        level = value;
    }
}
