using Godot;
using Godot.Collections;
using System;

public class Beat : Skill
{
    private int applyedDmgBonus = 0;
    private int acummulateStress = 0;
    private int stressNode = 0;
    private int holdActionIndex;

    protected static readonly string stressKey = "stress";


    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Frequencia Absoluta", "Meia Frequencia", "Fluxo", "Meia Pressao", "Pressao Absoluta" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        holdActionIndex = actionIndex;
        acummulateStress = GetStress(main);

        float correction = 2 - Math.Abs(actionIndex - 2);
        float stressMod = 1f / (int) (5 * Math.Pow(2, correction));
        float damageMod = 1f / (5 - actionIndex);
        float surgeMod = 1f / (1 + actionIndex);

        damageMod = (damageMod == 1 / 5f) ? 0 : damageMod;
        surgeMod = (surgeMod == 1 / 5f) ? 0 : surgeMod;
        surgeMod = surgeMod / 2;

        var levelToThisCritic = level + critic;

        int surgeBonus = (int) (levelToThisCritic * surgeMod);
        int dmgBonus = (int)(levelToThisCritic * damageMod);
        int stressBonus = (int)(levelToThisCritic * stressMod);


        if (main.GetActualSurge() + surgeBonus <= main.GetTotalSurge())
            main.AddActualSurge(surgeBonus);
        else
            main.SetActualSurge(main.GetTotalSurge());
        
        main.AddExtraDamage(dmgBonus);
        applyedDmgBonus = dmgBonus;
        acummulateStress += stressBonus;

        int strValue = main.GetTotalAtributeValue(MyEnum.Atribute.STR);
        stressNode = 3*acummulateStress/strValue;

        SetStress(main, acummulateStress);

        return new MessageNotificationData(
            notificationText, new object[] { dmgBonus, surgeBonus, stressBonus, stressNode+1 }, effectImage
        );

    }


    public int GetStress(MainInterface main)
    {
        return MyStatic.GetGameData<int>(main, stressKey, 0);
    }

    public void SetStress(MainInterface main, int stress)
    {
        main.SetGameDataByKey(stressKey, stress);
    }




    public int GetActionIndex()
    {
        return holdActionIndex;
    }


    public override void DoEndMechanicLogic() {
        main.AddExtraDamage(-applyedDmgBonus);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}