using Godot;
using Godot.Collections;
using System;

public class Zetsu : Skill
{
    int agiDefense;
    int strDefense;
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Zetsu" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        this.main = main;

        agiDefense = main.GetActualAgiDefense();
        strDefense = main.GetActualStrDefense();
        guard = main.GetGuard();

        ModifyDefenseFactors(0.5f);


        return new MessageNotificationData(
            notificationText, new object[] { 3*level, level }, effectImage
        );
        //@turn win of surge
    }

    
    public override void DoEndMechanicLogic()
    {
        ModifyDefenseFactors(1);
    }


    private void ModifyDefenseFactors(float mod)
    {
        main.SetActualAgiDefense((int)(agiDefense*mod));
        main.SetActualStrDefense((int)(strDefense *mod));
        main.SetGuard((int)(guard *mod));
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}