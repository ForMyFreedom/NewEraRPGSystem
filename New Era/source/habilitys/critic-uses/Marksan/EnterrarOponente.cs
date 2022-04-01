using Godot;
using Godot.Collections;
using System;

public class EnterrarOponente : CriticUse
{
    int damageExtra;

    //In this use, the critic value means the amount of meters!
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = critic*10;
        
        if (critic < 0)
            critic = result / 4;

        damageExtra = (int)(1.5 * critic);
        main.AddExtraDamage(damageExtra);

        main.CreateNewNotification(MyStatic.GetNotificationText(baseMessage, result, damageExtra),
            injectedWork.GetBaseImage());

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damageExtra);
    }

    public int RequestCriticTest(MainInterface main)
    {
        return main.RequestAtributeRoll(MyEnum.Atribute.AGI) / 10;
    }
}
