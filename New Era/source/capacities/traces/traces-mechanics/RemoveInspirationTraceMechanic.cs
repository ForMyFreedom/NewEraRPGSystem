using Godot;
using System;

public class RemoveInspirationTraceMechanic : TraceMechanic
{
    [Export]
    private float linearMod = 1;
    [Export]
    private int constMod = 0;
    [Export]
    private int removeByConstant = 10;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int removeByPercentage = (int)(main.GetInspiration() * linearMod + constMod);
        int removeValue = (removeByPercentage>removeByConstant) ? removeByPercentage : removeByConstant;

        main.AddInspiration(-removeValue);

        return new MessageNotificationData(
            baseMessage, new object[] {removeValue}, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
