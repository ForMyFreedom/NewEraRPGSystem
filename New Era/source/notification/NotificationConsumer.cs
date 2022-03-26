using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class NotificationConsumer : Resource
{
    [Export]
    private bool isSingleton = true;

    private bool isActive = false;
    protected MainInterface main;

    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (isSingleton && isActive) return;
        DoMechanicLogic(main, actionIndex, critic);
        ConnectToLastNotification(main);
        isActive = true;
    }

    public void DoEndMechanic(object obj)
    {
        if (this != obj) return;
        DoEndMechanicLogic();
        isActive = false;
    }

    public abstract void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    public abstract void DoEndMechanicLogic();

    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }
}
