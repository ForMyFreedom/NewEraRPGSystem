using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class Work : Resource, IPlayerDataConsumer
{
    [Export]
    protected string workName;
    [Export]
    protected Texture baseImage;
    [Export(PropertyHint.MultilineText)]
    protected string pathDescription;
    [Export]
    protected Skill[] skills = { };
    [Export(PropertyHint.MultilineText)]
    protected string description;
    [Export(PropertyHint.MultilineText)]
    protected string maestryDescription;
    [Export]
    protected MyEnum.Work enumWork;
    [Export]
    protected MyEnum.Atribute relationedAtribute;
    [Export]
    private int level;
    [Export]
    //private Array<int> worksUps;


    private WorkPlayerData workPlayerData;

    public abstract void DoFirstUpStep(MainInterface gui);
    public abstract void DoSecondUpStep(MainInterface gui);
    public abstract void DoThirdUpStep(MainInterface gui);
    public abstract void DoForthUpStep(MainInterface gui);

    public abstract int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex=0);


    public void InjectPlayerData(IVolatilePlayerData playerData)
    {
        workPlayerData = (WorkPlayerData) playerData;
    }


    public String GetWorkName()
    {
        return workName;
    }

    public Texture GetBaseImage()
    {
        return baseImage;
    }

    public Skill[] GetSkillList()
    {
        return skills;
    }

    public void SetSkillList(Skill[] skills)
    {
        this.skills = skills;
    }

    public string GetDescription()
    {
        return description;
    }

    public MyEnum.Work GetEnumWork()
    {
        return enumWork;
    }

    public string GetPathDescription()
    {
        return pathDescription;
    }

    public string GetMaestryDescription()
    {
        return maestryDescription;
    }
    
    public MyEnum.Atribute GetRelationedAtribute()
    {
        return workPlayerData.GetRelationedAtribute();
    }

    public void SetRelationedAtribute(MyEnum.Atribute atr) //no one is using this... but some of them should!
    {
        workPlayerData.SetRelationedAtribute(atr);
    }

    public int GetLevel()
    {
        return workPlayerData.GetLevel();
    }

    public void SetLevel(int level)
    {
        workPlayerData.SetLevel(level);
    }

    public Array<int> GetWorksUp()
    {
        return workPlayerData.GetWorksUps();
    }

    public void SetWorksUp(Array<int> worksUps)
    {
        workPlayerData.SetWorksUps(worksUps);
    }

    protected String GetCreateCriticMessage()
    {
        return "Voce precisa criar um uso de critico";
    }

    protected String GetCreateTechMessage()
    {
        return "Voce precisa criar uma tecnica";
    }
}