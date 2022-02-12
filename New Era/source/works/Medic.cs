using Godot;
using System;

public class Medic : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddMind(1);
        gui.AddAnSkillLevel(enumWork, 0, 5);
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

    public override int GetBaseDamage(MainInterface gui, int actionIndex = 0)
    {
        return 0;
    }
}
