using Godot;
using Godot.Collections;
using System;

public class SaberTudo : ItemCode
{
    [Export]
    private Texture image;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(message, null, image);
    }


    public override void DoEndMechanicLogic() { }


    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
