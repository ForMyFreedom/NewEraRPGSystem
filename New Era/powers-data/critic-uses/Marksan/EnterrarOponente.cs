using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;
using Statics.Enums;

public class EnterrarOponente : CriticUse
{
    int damageExtra;

    //In this use, the critic value means the amount of meters!
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        if (critic < 0)
            critic = result / 4;

        damageExtra = (int)(1.5 * critic);
        main.AddExtraDamage(damageExtra);

        main.CreateNewNotification(GetNotificationText(result, damageExtra),
            injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damageExtra);
    }
}
