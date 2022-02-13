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
    protected int ofensiveLevel;
    [Export]
    protected int suportLevel;
    [Export]
    protected int level;
    [Export]
    protected int modValue;


    protected Work[] injectedWorks;


    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = 0)
    {
        ExecuteAllCritics(main);
        DoAttackRollNotification(main);
    }

    
    public void ExecuteAllCritics(MainInterface main)
    {
        for (int i = 0; i < criticUses.Length; i++)
            criticUses[i].DoMechanic(main, actionIndexOfCritics[i], powerOfCritics[i]);
    }

    public void DoAttackRollNotification(MainInterface main)
    {
        int rollValue = CalculateRollValue();
        int sumValue = CalculateSumValue(main);
        int damage = CalculateBaseDamage(main) + ofensiveLevel +main.GetExtraDamage();

        int result = RollCode.GetRandomAdvancedRoll(rollValue, sumValue, modValue);

        main.CreateNewNotification(
            $"Resultado da Tecnica {techniqueName}: {result}"+GetDamageText(damage),
            injectedWorks[0].GetBaseImage()
        );
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
            value += main.GetAtributeNodeByEnum(work.GetRelationedAtribute()).GetAtributeValue();
        }

        return value/injectedWorks.Length;
    }


    private int CalculateBaseDamage(MainInterface main)
    {
        int value = 0;

        foreach (Work work in injectedWorks)
        {
            value += work.GetBaseDamage(main, 0); //@ GET WEAPON ACTION INDEX!!
        }

        return value / injectedWorks.Length;
    }


    private string GetDamageText(int damage)
    {
        if (damage <= 0)
            return "";
        else
            return $"\n Voce causa {damage} de Dano";
    }




    public override void DoEndMechanicLogic() { }


    public String GetTechniqueName()
    {
        return techniqueName;
    }

    public MyEnum.Work[] GetRelatedWorks()
    {
        return relatedWorks;
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

    public int GetLevel()
    {
        return level;
    }

    public int GetOfensiveLevel()
    {
        return ofensiveLevel;
    }

    public int GetSuportLevel()
    {
        return suportLevel;
    }

    public void InjectWorks(Work[] ws)
    {
        injectedWorks = ws;
    }
}
