
public class Shooter : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddSenses(2);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreateCriticMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.AddAnSkillLevel(enumWork, 0, 10);
    }

    public override void DoForthUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! " +
            "Escolha entre: \n" + maestryDescription, baseImage);
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        return weaponDamage;
    }
}