using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class NotificationConsumer : Resource
{
    [Export]
    private bool isSingleton = true;
    [Export]
    private bool toDispendSurge = true;


    private bool isActive = false;
    protected MainInterface main;

    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (isSingleton && isActive) return;
        ResolveSurgeDispension(main, critic);
        critic = GetCriticIfNotDetermined(critic);
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
    public abstract int RequestCriticTest(MainInterface main);

    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }

    protected int GetCriticIfNotDetermined(int critic)
    {
        if (critic < 0)
            return RequestCriticTest(main);
        else
            return critic;
    }

    private void ResolveSurgeDispension(MainInterface main, int critic)
    {
        if (!toDispendSurge) return;
        int maximumUseOfSurge = main.GetMaximumUseOfSurge();
        if (critic > maximumUseOfSurge)  critic = maximumUseOfSurge;
        if (critic < 0) critic = 0;

        main.AddActualSurge(-critic);
    }
}
