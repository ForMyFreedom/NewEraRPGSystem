using Godot;
using Godot.Collections;
using System;

public class OlhosQueVeemADanca : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        var seeCritic = main.RequestAtributeRoll(MyEnum.Atribute.SEN)/10;
        var danceCritic = main.RequestSkillRoll(main.GetSkillByWorkAndIndex(relatedWork, 0).GetSkillName())/10;
        var useLimit = (int)(main.GetMind() / 3);

        main.AddActualSurge(-10);

        return new MessageNotificationData(
            baseMessage, new object[] {seeCritic, danceCritic, useLimit}, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}
