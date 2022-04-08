using Godot;
using Godot.Collections;
using System;

public class Ren : Skill
{
    int damage;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Ren 1/4", "Rem 1/3", "Rem 1/2", "Ren Total" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        damage = GetDamage(actionIndex, critic);
        main.AddExtraDamage(damage);

        return new MessageNotificationData(
            notificationText, new object[] { damage, damage, damage/5 }, effectImage
        );

        //@turn lost of life
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damage);
    }


    private int GetDamage(int actionIndex, int mod)
    {
        return (int)(2*(level + mod))/(4-actionIndex);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}