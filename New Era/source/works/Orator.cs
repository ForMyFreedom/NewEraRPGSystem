using Godot;
using System;

public class Orator : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddCharisma(1);
        gui.CreateNewNotification("Distribuia 5 pontos entre Lideranca e Manipulacao", baseImage);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreatePowerMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + pathDescription, baseImage);
    }
}
