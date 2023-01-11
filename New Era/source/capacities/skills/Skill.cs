using Godot;
using Godot.Collections;
using System;

public abstract class Skill : NotificationConsumer, IPlayerDataConsumer
{
    [Export]
    protected string skillName;
    [Export]
    protected CSharpScript wayOfLevelCalculeScript;
    [Export]
    protected String skillDescription;
    [Export(PropertyHint.MultilineText)]
    protected String notificationText;
    [Export(PropertyHint.MultilineText)]
    protected String mechanicDescription;
    [Export]
    private Array<string> mechanicOptions;

    private WayOfCalculeSkill wayOfLevelCalcule;
    protected SkillPlayerData skillPlayerData;
    protected Texture effectImage;
    protected int level;

    public Array<string> GetTextOfMechanicButtons()
    {
        return mechanicOptions;
    }

    public override abstract MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1);
    public override abstract void DoEndMechanicLogic();


    public void InjectPlayerData(IVolatilePlayerData playerData)
    {
        skillPlayerData = (SkillPlayerData) playerData;
        effectImage = GetEffectImage();
        level = GetLevel();
    }

    public IVolatilePlayerData GetVolatilePlayerData()
    {
        return skillPlayerData;
    }


    public String GetSkillName()
    {
        return skillName;
    }

    public void PlayWayOfLevelCalcule(WorkTree workTree, int workIndex, int skillIndex, int _level)
    {
        wayOfLevelCalcule = (WayOfCalculeSkill)wayOfLevelCalculeScript.New();
        wayOfLevelCalcule.CalculeLevelSkill(workTree, workIndex, skillIndex, _level);
    }


    public int GetLevel()
    {
        return skillPlayerData.GetLevel();
    }

    public void SetLevel(int l)
    {
        skillPlayerData.SetLevel(l);
    }

    public void AddLevel(int add)
    {
        SetLevel(GetLevel() + add);
    }


    public String GetSkillDescription()
    {
        return skillDescription;
    }

    public void SetSkillDescription(String description)
    {
        skillDescription = description;
    }

    public Texture GetEffectImage()
    {
        return skillPlayerData.GetTexture();
    }

    public String GetMechanicDescription()
    {
        return mechanicDescription;
    }

    public void SetMechanicDescription(String description)
    {
        mechanicDescription = description;
    }
}