using Godot;

public interface IColorsData
{
    int GetColorfullHakiLevel(int haki);
    HakiColors GetColorEnum();
    string GetName();
    string GetDescription();
    int GetLevel();
}

public class ColorsData : Resource, IColorsData
{
    [Export]
    protected HakiColors colorEnum;
    [Export]
    protected string name;
    [Export]
    protected string description;
    [Export]
    protected int level;

    public int GetColorfullHakiLevel(int haki)
    {
        return (int)(haki * (1 + 0.10 * (level - 1)));
    }


    public HakiColors GetColorEnum()
    {
        return colorEnum;
    }

    public new string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetLevel()
    {
        return level;
    }
}



public enum HakiColors
{
    MelissaBlack, AmeikoYellow, AzazelRed, AzazelSilver,
}
