using Godot;
using System;
using System.Text;

public class MainInterface : Control
{
    [Export]
    private PackedScene playerScene;
    [Export]
    private NodePath sheetOpenButtonPath;

    private Player player;

    public override void _Ready()
    {
        player = playerScene.Instance<Player>();
        GetNode(sheetOpenButtonPath).Connect("button_up", this, "_OnOpenSheet");
    }


    public void _OnOpenSheet()
    {
        OS.ShellOpen(player.GetSheetURL());
    }

}

