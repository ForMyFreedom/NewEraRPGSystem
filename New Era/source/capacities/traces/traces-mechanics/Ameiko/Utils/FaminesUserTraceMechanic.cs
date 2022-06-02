using Godot;
using System;

public abstract class FaminesUserTraceMechanic : TraceMechanic
{
    [Export]
    protected int dmgBonus;

    protected static readonly string famineKey = "famine";

    protected MessageNotificationData GetFuryResult(MainInterface main)
    {
        int dmgRecived = dmgBonus / 2;

        main.AddExtraDamage(dmgBonus);
        main.AddActualLife(-dmgRecived);
        main.SetGameDataByKey(famineKey, main.GetTotalAtributeValue(MyEnum.Atribute.STR));

        return new MessageNotificationData(baseMessage, new object[] {dmgBonus, dmgRecived}, trace.GetTraceImage());
    }

    protected int GetFamine(MainInterface main)
    {
        var savedFamine = main.GetGameDataByKey(famineKey);
        return (savedFamine != null) ? (int)savedFamine : 0;
    }

    protected void AddFamine(MainInterface main, int sum)
    {
        main.SetGameDataByKey(famineKey, GetFamine(main) + sum);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
