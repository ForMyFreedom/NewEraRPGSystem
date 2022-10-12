using Godot.Collections;

public class Exploration : Skill
{
    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { };
    }

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return null;
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}