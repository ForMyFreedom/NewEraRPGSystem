using Godot;
using Godot.Collections;
using System;

public class Beat : Skill
{
    private int applyedDmgBonus = 0;
    private int acummulateStress = 0;
    private int stressNode = 0;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Frequencia Absoluta", "Meia Frequencia", "Fluxo", "Meia Pressao", "Pressao Absoluta" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        float correction = 2 - Math.Abs(actionIndex - 2);
        float stressMod = 1f / (int) (5 * Math.Pow(2, correction));
        float damageMod = 1f / (5 - actionIndex);
        float surgeMod = 1f / (1 + actionIndex);

        damageMod = (damageMod == 1 / 5f) ? 0 : damageMod;
        surgeMod = (surgeMod == 1 / 5f) ? 0 : surgeMod;
        surgeMod = surgeMod / 2;

        int surgeBonus = (int) (level * surgeMod) + critic;
        int dmgBonus = (int)(level * damageMod) + critic;
        int stressBonus = (int)(level * stressMod) + critic;


        main.AddActualSurge(surgeBonus);
        main.AddExtraDamage(dmgBonus - applyedDmgBonus);
        applyedDmgBonus = dmgBonus;
        acummulateStress += stressBonus;

        int strValue = main.GetAtributeNodeByEnum(MyEnum.Atribute.STR).GetAtributeTotalValue();
        stressNode = acummulateStress/strValue;

        return new MessageNotificationData(
            notificationText, new object[] { dmgBonus, surgeBonus, stressBonus, stressNode }, effectImage
        );

    }



    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}