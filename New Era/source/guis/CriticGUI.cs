using Godot;
using Godot.Collections;
using System.Linq;
using System;

public class CriticGUI : WindowDialog
{
    [Export]
    private NodePath criticBoxPath;
    [Export]
    private PackedScene singleCriticButtonPacked;

    private Work work;
    private Array<CriticUse> criticUses;

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Esc"))
            Hide();
    }

    public void PopupIt()
    {
        PopupCenteredRatio(0.5f);
    }

    public override void _Ready()
    {
        WindowTitle += work.GetWorkName();
        InitializeTree();
        Connect("popup_hide", this, "_OnPopupHide");
    }


    private void _OnPopupHide()
    {
        QueueFree();
    }


    private void InitializeTree()
    {
        Control criticBox = GetNode<Control>(criticBoxPath);
        
        for(int i=0; i < criticUses.Count; i++)
        {
            SingleCriticButton criticNode = singleCriticButtonPacked.Instance<SingleCriticButton>();
            criticNode.SetText(criticUses[i]);
            criticNode.SetCritic(criticUses[i]);
            criticNode.Connect("critic_activated", this, "_OnCriticActivated");
            criticBox.AddChild(criticNode);
        }
    }

    private void _OnCriticActivated(CriticUse use, int criticLimit, bool isLimitedCritic)
    {
        MainInterface main = (MainInterface) GetTree().CurrentScene;

        int critic = -1;

        int reachCritic = use.RequestCriticTest(main);
        if (isLimitedCritic)
            critic = criticLimit;

        if (use.GetCost() > critic) critic = use.GetCost();
        if (critic > reachCritic) critic = reachCritic;

        use.DoMechanic(main, 0, critic);
    }


    public void SetWork(Work w)
    {
        work = w;
    }

    public Array<CriticUse> GetCriticUses()
    {
        return criticUses;
    }

    public void SetCriticUses(Godot.Collections.Array uses)
    {
        criticUses = new Array<CriticUse>();
        foreach(CriticUse use in uses)
        {
            criticUses.Add(use);
        }
    }
}