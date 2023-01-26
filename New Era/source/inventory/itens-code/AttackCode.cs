using Godot;
using System;

public class AttackCode : ItemCode
{
    [Export]
    private readonly int weaponIndex;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.SetWeaponIndex(weaponIndex);
        main.ActivateTechnique(0);
        return null;
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
