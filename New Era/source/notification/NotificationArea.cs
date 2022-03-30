using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Linq;

public class NotificationArea : Control
{
    [Export]
    private NodePath bellPath;
    [Export]
    private NodePath turnPath;
    [Export]
    private NodePath defensePath;
    [Export]
    private NodePath animationPath;
    [Export]
    private NodePath notificationListPath;
    [Export]
    private NodePath quantNotificationsPath;

    [Export]
    private Texture blankTexture;

    private bool toShow = false;
    private ItemList notificationList;

    [Signal]
    public delegate void notification_deleted(Godot.Object obj);


    public override void _Ready()
    {
        notificationList = GetNode<ItemList>(notificationListPath);

        GetNode(notificationListPath).Connect("gui_input", this, "_OnNotificationListGuiInput");
        GetNode<Booble>(bellPath).GetTexture().Connect("gui_input", this, "_OnBellGuiInput");
        GetNode<Booble>(defensePath).GetTexture().Connect("gui_input", this, "_OnDefenseGuiInput");
    }



    public void CreateNewNotification(String message, Texture texture=null)
    {
        if (texture == null) texture = blankTexture;
        notificationList.AddItem(message, texture);
        GetNode<AnimationPlayer>(animationPath).Play("new_notification");
        ActualizeQuantNotificationsLabel();
    }

    public void DeleteNotification(int index)
    {
        if (index < 0) return;
        EmitSignal(nameof(notification_deleted), notificationList.GetItemMetadata(index));

        notificationList.RemoveItem(index);
        GetNode<AnimationPlayer>(animationPath).Play("del_notification");
        ActualizeQuantNotificationsLabel();

    }

    public void ConnectToLastNotification(Godot.Object obj, String funcName)
    {
        int index = notificationList.GetItemCount() - 1;
        notificationList.SetItemMetadata(index, obj);
        if (IsConnected(nameof(notification_deleted), obj, funcName)) return;
        this.Connect(nameof(notification_deleted), obj, funcName);
    }


    private void _OnNotificationListGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton buttonEvent = (InputEventMouseButton)@event;
        if (buttonEvent.Doubleclick)
        {
            DeleteNotification(TryGetTheSelectedNotificationIndex());
        }
    }


    private void _OnBellGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton buttonEvent = (InputEventMouseButton) @event;
        if (buttonEvent.ButtonIndex != (int) ButtonList.Left) return;

        if (buttonEvent.Pressed)
            toShow = !toShow;
        else
            return;

        if (toShow)
            GetNode<AnimationPlayer>(animationPath).Play("show");
        else
            GetNode<AnimationPlayer>(animationPath).Play("dishow");
    }


    private void _OnDefenseGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton buttonEvent = (InputEventMouseButton) @event;
        if (buttonEvent.ButtonIndex != (int)ButtonList.Left) return;
        if (buttonEvent.Pressed) return;

        GetNode<DefenseBooble>(defensePath).InvertTexture();
    }



    private void ActualizeQuantNotificationsLabel()
    {
        int quant = notificationList.Items.Count/3;
        if (quant > 0)
        {
            GetNode<Label>(quantNotificationsPath).Visible = true;
            GetNode<Label>(quantNotificationsPath).Text = quant.ToString();
        }
        else
        {
            GetNode<Label>(quantNotificationsPath).Visible = false;
        }
    }


    private int TryGetTheSelectedNotificationIndex()
    {
        try
        {
            return notificationList.GetSelectedItems()[0];
        }
        catch (Exception)
        {
            return -1;
        }
    }



    public Godot.Collections.Array GetNotifications()
    {
        Godot.Collections.Array notArray = notificationList.Items;
        Godot.Collections.Array notifications = new Godot.Collections.Array();
        for(int i = 3; i <= notArray.Count; i = i=i+3)
        {
            notifications.Add(new Godot.Collections.Array() {notArray[i-3],notArray[i-2]});
        }
        return notifications;
    }


    public void SetNotifications(Godot.Collections.Array notifications)
    {
        CleanAllNotificationsItens();

        foreach (Godot.Collections.Array not in notifications)
        {
            notificationList.AddItem((String)not[0], (Texture)not[1]);
        }

        ActualizeQuantNotificationsLabel();
    }


    private void CleanAllNotificationsItens()
    {
        notificationList.Clear();
    }
}
