using Godot;
using Godot.Collections;
using System;

public abstract class NotificationConsumer : Resource
{
    protected MainInterface main;

    public abstract void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1);
    public abstract void DoEndMechanicLogic();

    public void DoEndMechanic(object obj)
    {
        if (this != obj) return;
        DoEndMechanicLogic();
    }

    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }
}
