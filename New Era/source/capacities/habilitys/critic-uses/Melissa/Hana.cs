using Godot;

public class Hana : HakiUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = GetHakisColorRollResult(main, new[] { HakiColors.MelissaBlack }, critic);
        critic = result / 10;
        return new MessageNotificationData(baseMessage, new object[] { 2*critic }, criticImage, critic);
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return cost;
    }
}