using Godot;
using System;
using System.Collections;
using System.Linq;

public class NotificationArea : Control
{
    [Export]
    private NodePath bellPath;
    [Export]
    private NodePath animationPath;
    [Export]
    private NodePath notificationListPath;
    [Export]
    private NodePath quantNotificationsPath;

    [Export]
    private Texture blankTexture;

    private bool toShow = false;
    ItemList notificationList;

    public override void _Ready()
    {
        notificationList = GetNode<ItemList>(notificationListPath);
        GetNode(bellPath).Connect("gui_input", this, "_OnBellGuiInput");
        GetNode(notificationListPath).Connect("gui_input", this, "_OnNotificationListGuiInput");
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
        notificationList.RemoveItem(index);
        GetNode<AnimationPlayer>(animationPath).Play("del_notification");
        ActualizeQuantNotificationsLabel();
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
        {
            toShow = !toShow;
        }else return;

        if (toShow)
            GetNode<AnimationPlayer>(animationPath).Play("show");
        else
            GetNode<AnimationPlayer>(animationPath).Play("dishow");
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
        if (notifications == null) return;
        foreach(Godot.Collections.Array not in notifications)
        {
            notificationList.AddItem((String)not[0], (Texture)not[1]);
        }
        ActualizeQuantNotificationsLabel();
    }
}
