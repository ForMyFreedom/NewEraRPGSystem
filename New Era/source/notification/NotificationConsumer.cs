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

    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1, bool limitFree = false)
    {
        if (isSingleton && isActive) return;
        critic = GetCriticIfNotDetermined(main, critic);
        critic = DefineFinalCritic(main, critic, limitFree);

        if (!CanUseThisHability(main, critic))
            return;

        ConsumeCritic(main, critic);
        MessageNotificationData messageData = DoMechanicLogic(main, actionIndex, critic);

        if (messageData == null) return;
        CreateNotification(main, messageData, critic, main.GetMaximumUseOfSurge());
        ConnectToLastNotification(main);
        isActive = true;
    }

    public void DoEndMechanic(object obj)
    {
        if (this != obj) return;
        DoEndMechanicLogic();
        isActive = false;
    }

    public abstract MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
    public abstract void DoEndMechanicLogic();
    public abstract int RequestCriticTest(MainInterface main);

    protected void ConnectToLastNotification(MainInterface main)
    {
        this.main = main;
        main.ConnectToLastNotification(this, nameof(DoEndMechanic));
    }

    protected int GetCriticIfNotDetermined(MainInterface main, int critic)
    {
        if (critic < 0)
            return RequestCriticTest(main);
        else
            return critic;
    }

    private int DefineFinalCritic(MainInterface main, int critic, bool limitFree)
    {
        if (!toDispendSurge) return critic;
        //int maximumUseOfSurge = main.GetMaximumUseOfSurge();
        //if (!limitFree && critic > maximumUseOfSurge)  critic = maximumUseOfSurge;
        if (critic < 0) critic = 0;

        return critic;
    }

    private bool CanUseThisHability(MainInterface main, int critic)
    {
        if (main.GetActualSurge() < critic)
            return false;
        else
            return true;
    }

    private void ConsumeCritic(MainInterface main, int critic)
    {
        if (toDispendSurge)
            main.AddActualSurge(-critic/2);
    }

    private void CreateNotification(MainInterface main, MessageNotificationData messageData, int critic, int limit)
    {
        main.CreateNewNotification(MyStatic.GetNotificationText(
            messageData.GetMessage(), new int[2] {critic, limit}, messageData.GetData()
        ), messageData.GetTexture());
    }
}
