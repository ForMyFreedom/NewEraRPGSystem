using Godot;
using System;

public class FamineTraceMechanic : FaminesUserTraceMechanic
{
    [Export(PropertyHint.MultilineText)]
    private string furyText;
    [Export]
    private Texture furyFamineTexture;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        MessageNotificationData result;

        AddFamine(main, 2);
        int famine = GetFamine(main);

        if (FamineSurpassStrength(main))
            result = GetFuryResult(main);
        else
            result = GetProgressionResult(famine);

        return result;
    }

    public override void DoEndMechanicLogic()
    {
        if (!FamineSurpassStrength(main)) return;
        main.AddExtraDamage(-dmgBonus);
    }


    private MessageNotificationData GetProgressionResult(int famine)
    {
        return new MessageNotificationData(
            baseMessage, new object[] { famine }, trace.GetTraceImage()
        );
    }


    private bool FamineSurpassStrength(MainInterface main)
    {
        return GetFamine(main) > main.GetTotalAtributeValue(MyEnum.Atribute.STR);
    }

}
