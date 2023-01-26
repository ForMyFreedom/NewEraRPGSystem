using Godot;

public class Hana : HakiUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = GetHakisColorRollResult(main, critic);
        critic = result / 10;
        return new MessageNotificationData(baseMessage, new object[] { 2*critic }, criticImage, critic);
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }

    protected override HakiColors[] GetHakiUseColors()
    {
        return new[] { HakiColors.MelissaBlack };
    }
}