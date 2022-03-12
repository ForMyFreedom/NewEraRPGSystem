using Godot;
using System;

using Capacities.Interface;
using Capacities;

public class SingleCriticButton : Control
{
    [Export]
    private NodePath textPath;
    [Export]
    private NodePath rectSelectPath;

    [Signal]
    public delegate void critic_activated(CriticUse use);

    private CriticUseInterface use;

    public override void _Ready()
    {
        GetNode(textPath).Connect("gui_input", this, "_OnGuiInput");
        Connect("ready", this, "_OnThisReady");
    }

    private void _OnThisReady()
    {
        RectMinSize = new Vector2(RectMinSize.x, GetNode<Control>(textPath).RectSize.y*1.8f);
    }


    private void _OnGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick)
            EmitSignal(nameof(critic_activated), use);
        //@implement color rect logic to responsitivity
    }


    public void SetText(CriticUseInterface use)
    {
        GetNode<RichTextLabel>(textPath).BbcodeText = GetFormatedText(use);
    }

    public void SetCritic(CriticUseInterface use)
    {
        this.use = use;
    }



    private String GetFormatedText(CriticUseInterface use)
    {
        return $"[b]{use.GetUseName()} [{GetCriticCost(use)}][/b]: {use.GetText()}";
    }

    private String GetCriticCost(CriticUseInterface use)
    {
        if (use.GetCost() < 0)
            return "N";
        else
            return use.GetCost().ToString();
    }
}
