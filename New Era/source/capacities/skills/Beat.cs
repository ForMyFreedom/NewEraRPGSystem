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
        surgeMod = surgeMod / 3;

        int surgeBonus = (int) (level * surgeMod) + critic;
        int dmgBonus = (int)(level * damageMod) + critic;
        int stressBonus = (int)(level * stressMod) + critic;


        main.AddActualSurge(surgeBonus);
        main.AddExtraDamage(dmgBonus - applyedDmgBonus);
        applyedDmgBonus = dmgBonus;
        acummulateStress += stressBonus;

        int strValue = main.GetTotalAtributeValue(MyEnum.Atribute.STR);
        stressNode = 3*acummulateStress/strValue;

        SetStress(main, acummulateStress);

        return new MessageNotificationData(
            notificationText, new object[] { dmgBonus, surgeBonus, stressBonus, stressNode }, effectImage
        );

    }


    public int GetStress(MainInterface main)
    {
        return GetGameData<int>(main, stressKey, 0);
    }

    public void SetStress(MainInterface main, int stress)
    {
        main.SetGameDataByKey(stressKey, stress);
    }


    public T GetGameData<T>(MainInterface main, string key, T defaultResponse)  //@ put in mystatic
    {
        var data = main.GetGameDataByKey(key);
        return (data != null) ? (T)data : defaultResponse;
    }





    public int GetActionIndex()
    {
        return holdActionIndex;
    }


    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}