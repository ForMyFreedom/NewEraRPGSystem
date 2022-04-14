using Godot;
using Godot.Collections;

public class WorkPlayerData : Resource, IVolatilePlayerData
{
    [Export]
    private MyEnum.Work workEnum;
    [Export]
    private MyEnum.Atribute relationedAtribute;
    [Export]
    private int level;
    [Export]
    private Array<int> worksUps;

    public MyEnum.Work GetWorkEnum()
    {
        return workEnum;
    }

    public MyEnum.Atribute GetRelationedAtribute()
    {
        return relationedAtribute;
    }

    public void SetRelationedAtribute(MyEnum.Atribute atribute)
    {
        relationedAtribute = atribute;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int value)
    {
        level = value;
    }

    public Array<int> GetWorksUps()
    {
        return worksUps;
    }

    public void SetWorksUps(Array<int> array)
    {
        worksUps = array;
    }
}
