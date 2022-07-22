using Godot;
using System;

public class Fighter : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.CreateNewNotification("+3 entre STR/AGI/SEN", baseImage);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateCriticMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateTechMessage(), baseImage);
    }

    public override void DoForthUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + maestryDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        int str = gui.GetTotalAtributeValue(MyEnum.Atribute.STR);
        int agi = gui.GetTotalAtributeValue(MyEnum.Atribute.AGI);
        return (str + agi) / 2;
    }
}
