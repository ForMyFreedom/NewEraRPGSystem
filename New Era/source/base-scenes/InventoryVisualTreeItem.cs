using Godot;
using System;

public class InventoryVisualTreeItem : Control
{
    [Export]
    private NodePath editTextButtonPath;
    [Export]
    private NodePath quantEditPath;
    [Export]
    private NodePath nameEditPath;
    [Export]
    private NodePath descEditPath;
    [Export]
    private NodePath lineEditControlPath;

    [Signal]
    public delegate void item_activated(int index);
    [Signal]
    public delegate void quant_modified(int quant, int index);
    [Signal]
    public delegate void name_modified(string name, int index);
    [Signal]
    public delegate void desc_modified(string desc, int index);

    public override void _Ready()
    {
        GetNode(editTextButtonPath).Connect("button_up", this, "_OnEditTextButtonUp");
        GetNode(descEditPath).Connect("gui_input", this, "_OnLineEditGuiInput");

        GetNode<LineEdit>(quantEditPath).Text = (String) GetMeta("_quant");
        GetNode<LineEdit>(nameEditPath).Text = (String) GetMeta("_name");
        GetNode<LineEdit>(descEditPath).Text = (String) GetMeta("_desc");

        GetNode(quantEditPath).Connect("text_changed", this, "_OnQuantTextChanged");
        GetNode(nameEditPath).Connect("text_changed", this, "_OnNameTextChanged");
        GetNode(descEditPath).Connect("text_changed", this, "_OnDescTextChanged");
    }


    private void _OnQuantTextChanged(string newString)
    {
        EmitSignal(nameof(quant_modified), TryParse(newString), GetIndex());
    }

    private void _OnNameTextChanged(string newString)
    {
        EmitSignal(nameof(name_modified), newString, GetIndex());
    }

    private void _OnDescTextChanged(string newString)
    {
        EmitSignal(nameof(desc_modified), newString, GetIndex());
    }



    private void _OnEditTextButtonUp()
    {
        foreach (Control child in GetNode(lineEditControlPath).GetChildren()){
            if(child is LineEdit)
            {
                LineEdit line = (LineEdit)child;
                line.Editable = !line.Editable;
            }
        }
    }

    private void _OnLineEditGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        InputEventMouseButton mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick && !GetNode<LineEdit>(descEditPath).Editable)
            EmitSignal(nameof(item_activated), GetIndex());
    }


    private int TryParse(string str)
    {
        try
        {
            return int.Parse(str);
        }
        catch (Exception)
        {
            return 1;
        }
    }
}
