using Godot;
using System;

public class AkumaNoMi : Work
{
    [Export]
    private int baseDamage;

    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddAnAtributeLevel(relationedAtribute, 3);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreatePowerMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + maestryDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        return baseDamage + GetLevel()/2;
    }
}
