using Godot;
using System;

public class Orator : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddCharisma(2);
        gui.CreateNewNotification("Distribuia 6 pontos entre Lideranca e Manipulacao", baseImage);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateCriticMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification("Distribuia 12 pontos entre Lideranca e Manipulacao", baseImage);
    }

    public override void DoForthUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + maestryDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        return 0;
    }
}
