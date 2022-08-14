using Godot;
using Godot.Collections;
using System;

public class Muteki : CriticUse
{
    int guard;


    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int guard = 2*(main.RequestAtributeRoll(MyEnum.Atribute.VON) / 10);
        main.AddGuard(guard);

        return new MessageNotificationData(
            baseMessage, new object[] { guard }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddGuard(-guard);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestSkillRoll(injectedWork.GetSkillList()[0].GetSkillName()) / 10;
    }
}
