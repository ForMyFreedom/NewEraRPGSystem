using Godot;
using System;

public class Haki : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.CreateNewNotification("Distribua 3 pontos entre Ten, Zetsu e Ren", baseImage);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateCriticMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateTechMessage(), baseImage);
    }

    public override void DoForthUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + maestryDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        return weaponDamage + gui.GetAtributeNodeByEnum(relationedAtribute).GetAtributeValue()/2;
    }
}