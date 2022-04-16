using Godot;
using Godot.Collections;
using System.Linq;

public class CapacitiesPlayerData : Resource
{
    [Export]
    private WorkPlayerData[] allWorkData;
    [Export]
    private Array<Array<SkillPlayerData>> allSkillData;

    public WorkPlayerData GetWorkPlayerData(MyEnum.Work workEnum)
    {
        return allWorkData.Where(w => w.GetWorkEnum() == workEnum).First();
    }

    public SkillPlayerData[] GetAllSkillFromWorkPlayerData(MyEnum.Work workEnum)
    {
        return allSkillData
            .Where(s => s.Count>0)
            .Where(s => s[0].GetWorkEnum() == workEnum).First().ToArray();
    }

    public SkillPlayerData GetSkillPlayerData(MyEnum.Work workEnum, int index)
    {
        return GetAllSkillFromWorkPlayerData(workEnum)[index];
    }
}
