using Godot;
using Godot.Collections;
using System;

public abstract class Technique : NotificationConsumer
{
    [Export]
    protected String techniqueName;
    [Export]
    protected MyEnum.Work[] relatedWorks;
    [Export]
    protected CriticUse[] criticUses;
    [Export]
    protected int[] powerOfCritics;
    [Export]
    protected int[] actionIndexOfCritics;
    [Export]
    protected int modValue;
    [Export]
    protected Texture customImage;

    protected Work[] injectedWorks;


    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = 0)
    {
        ExecuteAllCritics(main);
        DoAttackRollNotification(main, critic);
        return null;
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return DoRollOfTechnique(main) / 10;
    }


    public void ExecuteAllCritics(MainInterface main)
    {
        for (int i = 0; i < criticUses.Length; i++)
            criticUses[i].DoMechanic(main, actionIndexOfCritics[i], powerOfCritics[i]);
    }

    public void DoAttackRollNotification(MainInterface main, int critic)
    {
        int damage = CalculateBaseDamage(main) + main.GetExtraDamage();
        int result = critic * 10;

        main.CreateNewNotification(
            $"Resultado da Tecnica {techniqueName}: {result}"+GetDamageText(damage),
            GetTechniqueImage()
        );
    }



    public int DoRollOfTechnique(MainInterface main)
    {
        int rollValue = CalculateRollValue();
        int sumValue = CalculateSumValue(main);
        return RollCode.GetRandomAdvancedRoll(rollValue, sumValue, modValue);
    }



    private int CalculateRollValue()
    {
        int value = 0;

        foreach(Work work in injectedWorks)
        {
            value += work.GetLevel();
        }

        return value/injectedWorks.Length;
    }

    private int CalculateSumValue(MainInterface main)
    {
        int value = 0;

        foreach(Work work in injectedWorks)
        {
            value += main.GetAtributeNodeByEnum(work.GetRelationedAtribute()).GetAtributeTotalValue();
        }

        return value/injectedWorks.Length;
    }


    private int CalculateBaseDamage(MainInterface main)
    {
        int value = 0;

        foreach (Work work in injectedWorks)
        {
            value += work.GetBaseDamage(main, main.GetSelectedWeaponDamage());
        }

        return value / injectedWorks.Length;
    }


    private string GetDamageText(int damage)
    {
        if (damage <= 0)
            return "";
        else
            return $"\n {damage} Dano/Guarda";
    }




    public override void DoEndMechanicLogic() { }


    public Texture GetTechniqueImage()
    {
        if (customImage != null)
            return customImage;
        else
            return injectedWorks[0].GetBaseImage();
    }


    public String GetTechniqueName()
    {
        return techniqueName;
    }

    public MyEnum.Work[] GetRelatedWorks()
    {
        return relatedWorks;
    }

    public Work[] GetInjectedWorks()
    {
        return injectedWorks;
    }

    public CriticUse[] GetCriticUses()
    {
        return criticUses;
    }

    public int[] GetPowerOfCritics()
    {
        return powerOfCritics;
    }

    public int[] GetActionIndexOfCritics()
    {
        return actionIndexOfCritics;
    }

    public void InjectWorks(Work[] ws)
    {
        injectedWorks = ws;
    }
}
