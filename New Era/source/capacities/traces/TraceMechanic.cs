using Godot;
using System;

public abstract class TraceMechanic : NotificationConsumer
{
    [Export(PropertyHint.MultilineText)]
    protected string baseMessage;

    protected Trace trace;

    public void InjectTrace(Trace trace)
    {
        this.trace = trace;
    }

    public override abstract void DoEndMechanicLogic();
    public override abstract MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    public override abstract int RequestCriticTest(MainInterface main);
}
