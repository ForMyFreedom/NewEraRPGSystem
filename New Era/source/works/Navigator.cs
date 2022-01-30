using Godot;
using System;

public class Navigator : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddSenses(1);
        gui.CreateNewNotification("Distribuia 5 pontos entre Pilotagem e Previsao", baseImage);
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
