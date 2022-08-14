using Godot.Collections;

public class Gen : Skill //turn's to Kyo
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Kyo" };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(
            notificationText, new object[] { 3*level,2*level,level }, effectImage
        );

    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}