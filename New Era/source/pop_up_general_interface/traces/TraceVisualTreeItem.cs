using Godot;
using System;

public class TraceVisualTreeItem : Control
{
    [Export]
    private NodePath nameLineEditPath;
    [Export]
    private NodePath textLineEditPath;
    [Export]
    private NodePath traceImagePath;

    [Signal]
    public delegate void trace_activated(int traceIndex);

    public override void _Ready()
    {
        GetNode<LineEdit>(nameLineEditPath).Text = (String) GetMeta("_name");
        GetNode<LineEdit>(textLineEditPath).Text = (String) GetMeta("_text");
        GetNode<LineEdit>(nameLineEditPath).HintTooltip = (String)GetMeta("_name");
        GetNode<LineEdit>(textLineEditPath).HintTooltip = (String)GetMeta("_text");

        GetNode(textLineEditPath).Connect("gui_input", this, "_OnGuiInput");
    }

    private void _OnGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick)
            EmitSignal(nameof(trace_activated), GetIndex());
    }
}
