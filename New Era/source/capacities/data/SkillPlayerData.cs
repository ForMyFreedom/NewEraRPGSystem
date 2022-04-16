using Godot;

public class SkillPlayerData : Resource, IVolatilePlayerData
{
    [Export]
    private Texture skillTexture;
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

    public Texture GetTexture()
    {
        return skillTexture;
    }

    public void SetTexture(Texture texture)
    {
        skillTexture = texture;
    }
}
