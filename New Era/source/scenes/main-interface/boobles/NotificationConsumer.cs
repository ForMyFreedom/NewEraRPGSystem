using Godot;
using Godot.Collections;
using System;
using System.Linq;

using Entities;

public abstract class NotificationConsumer : Resource
{
    protected MainInterface main;

    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if(!NotificationAlreadyExist(main))
            DoMechanicLogic(main, actionIndex, critic);
    }

    public void DoEndMechanic(object obj)
    {
        if (this != obj) return;
        DoEndMechanicLogic();
    }

    public abstract void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    public abstract void DoEndMechanicLogic();

    public bool NotificationAlreadyExist(MainInterface main) //@
    {
        object[] array = main.GetNotifications().Cast<object>().ToArray();
        object[] result = array.Select(notification => notification.ToString()).ToArray();
        return result.Contains(this);
    }


    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }
}
