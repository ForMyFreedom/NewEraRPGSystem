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
        GD.Print("thrid");
    }
}
