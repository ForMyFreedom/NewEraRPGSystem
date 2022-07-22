using Godot;
using Godot.Collections;
using System;

public class Rejuvenecer : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic=-1)
    {
        int surgePercentage = 2 * critic;

        Medicine medicine = GetMedicineSkill(main);
        int lifeRegen = medicine.GetRepairLife(critic * 10);
        int surgeRegen = (int)((surgePercentage / 100f)*lifeRegen);

        return new MessageNotificationData(
            baseMessage, new object[] {surgePercentage, lifeRegen, surgeRegen }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
    }



    private Medicine GetMedicineSkill(MainInterface main)
    {
        return (Medicine)main.GetSkillByWorkAndIndex(relatedWork, 0);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork)/10;
    }
}
