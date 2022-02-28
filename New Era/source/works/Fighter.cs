using Godot;
using System;

public class Fighter : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.CreateNewNotification("+1 STR/AGI/SEN", baseImage);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreatePowerMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui) //@
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + pathDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        int str = gui.GetAtributeNodeByEnum(MyEnum.Atribute.STR).GetAtributeValue();
        int agi = gui.GetAtributeNodeByEnum(MyEnum.Atribute.AGI).GetAtributeValue();
        return (str + agi) / 2;
    }
}
