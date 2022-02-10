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
            "Escolha entre: \n" + maestryDescription, baseImage);
    }
}
