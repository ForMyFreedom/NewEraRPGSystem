using Godot;
using Godot.Collections;
using System;
using System.Linq;

public abstract class NotificationConsumer : Resource
{
    [Export]
    protected bool isSingleton = true;
    [Export]
    protected bool toDispendSurge = true;
    [Export]
    protected bool canLimit = true;

    private bool isActive = false;
    protected MainInterface main;

    public void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (isSingleton && isActive) return;
        critic = GetCriticIfNotDetermined(main, critic);
        critic = DefineFinalCritic(main, critic, canLimit);

        if (!CanUseThisHability(main, critic))
            return;

        ConsumeCritic(main, critic);
        MessageNotificationData messageData = DoMechanicLogic(main, actionIndex, critic);

        if (messageData == null) return;
        if (messageData.CriticWasRenewed()) critic = messageData.GetRenewCritic();
        CreateNotification(main, messageData, critic);
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

    private int DefineFinalCritic(MainInterface main, int critic, bool canLimit)
    {
        if (!toDispendSurge)   return critic;
        if (critic < 0)        critic = 0;
        if (!CanUseThisHability(main, critic) && canLimit)
            critic = (int)(Math.Pow(main.GetActualSurge(),2) / GetCriticWaste(main.GetActualSurge()));
        return critic;
    }

    private bool CanUseThisHability(MainInterface main, int critic)
    {
        if (main.GetActualSurge() < GetCriticWaste(critic))
            return false;
        else
            return true;
    }

    private void ConsumeCritic(MainInterface main, int critic)
    {
        if (toDispendSurge)
            main.AddActualSurge(-GetCriticWaste(critic));
    }

    private void CreateNotification(MainInterface main, MessageNotificationData messageData, int critic)
    {
        main.CreateNewNotification(MyStatic.GetNotificationText(
            messageData.GetMessage(), critic, messageData.GetData()
        ), messageData.GetTexture());
    }

    private int GetCriticWaste(int value)
    {
        return (value/2 <= 0) ? 1 : value/2;
    }
}
