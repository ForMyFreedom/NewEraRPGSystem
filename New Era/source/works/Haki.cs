using Godot;
using System;

public class Haki : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
    }

    public override void DoThirdUpStep(MainInterface gui) //@
    {
    }

    public override int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0)
    {
        return 0;
    }
}