using Godot;
using System;

public class Artist : Work
{
    [Export]
    private int baseDamage;

    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddCharisma(1);
        gui.AddAnSkillLevel(enumWork, 0, 5);
        //@ maybe make the skillLevel here a request to distribuite in its variated 'arts'
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
        return baseDamage + gui.GetAtributeNodeByEnum(relationedAtribute).GetAtributeTotalValue()/2;
    }
}