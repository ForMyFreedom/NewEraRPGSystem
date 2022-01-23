using Godot;
using System;

public class Medic : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddMind(1);
        gui.AddSomeSkillLevel(5, 0, enumWork);
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
