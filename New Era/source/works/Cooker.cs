using Godot;
using System;

public class Cooker : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddSenses(1);
        gui.AddAnSkillLevel(enumWork, 0, 5);
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
