using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class NotificationConsumer : Resource
{
    [Export]
    private bool isSingleton = true;
    [Export]
    private CriticEntity criticEntity;

    private bool isActive = false;
    protected MainInterface main;


    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1, bool limitFree = false)
    {
        if (isSingleton && isActive) return;
        critic = criticEntity.RegulateCritic(main, critic, limitFree);
        if (critic < 0) return;

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


    public CriticEntity GetCriticEntity()
    {
        return criticEntity;
    }
}
