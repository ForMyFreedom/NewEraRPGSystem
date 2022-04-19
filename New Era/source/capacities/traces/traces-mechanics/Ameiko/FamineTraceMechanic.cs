using Godot;
using System;

public class FamineTraceMechanic : TraceMechanic
{
    [Export]
    private int dmgBonus;

    [Export(PropertyHint.MultilineText)]
    private string furyText;
    [Export]
    private Texture furyFamineTexture;

    private int famine;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        MessageNotificationData result;
        famine+=2;

        if (FamineSurpassStrength(main))
            result = GetFuryResult();
        else
            result = GetProgressionResult();

        return result;
    }

    public override void DoEndMechanicLogic()
    {
        if (!FamineSurpassStrength(main)) return;
        main.AddExtraDamage(-dmgBonus);
    }



    private MessageNotificationData GetFuryResult()
    {
        main.AddExtraDamage(dmgBonus);
        main.AddActualLife(-dmgBonus / 2);

        return new MessageNotificationData(furyText, null, furyFamineTexture);
    }

    private MessageNotificationData GetProgressionResult()
    {
        return new MessageNotificationData(
            baseMessage, new object[] { famine }, trace.GetTraceImage()
        );
    }


    private bool FamineSurpassStrength(MainInterface main)
    {
        return famine > main.GetAtributeNodeByEnum(MyEnum.Atribute.STR).GetAtributeTotalValue();
    }


    public int GetFamine()
    {
        return famine;
    }

    public void AddFamine(int value)
    {
        famine += value;
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
