using Godot;
using Godot.Collections;
using System;

public class SelectPlayer : Control
{
    [Export]
    private NodePath playerBoxContainerPath;
    [Export(PropertyHint.File)]
    private string playerFolderPath;
    [Export]
    private PackedScene playerButtonPacked;
    [Export]
    private PackedScene mainInterfacePacked;

    private Godot.Collections.Array playerStringPathArray;
    private PackedScene[] playersScenesPacked;
    private Player[] playersScenes;


    public override void _Ready()
    {
        LoadPlayersData();
        LoadPlayersButtons();
        MyStatic.CenterTheWindow();
    }


    private void LoadPlayersData()
    {
        playerStringPathArray = ListFilesInDiretory(playerFolderPath);
        playersScenesPacked = new PackedScene[playerStringPathArray.Count];
        playersScenes = new Player[playerStringPathArray.Count];

        for (int i = 0; i < playerStringPathArray.Count; i++)
        {
            playersScenesPacked[i] = ResourceLoader.Load<PackedScene>(playerFolderPath + playerStringPathArray[i]);
            playersScenes[i] = playersScenesPacked[i].Instance<Player>();
        }
    }


    private void LoadPlayersButtons()
    {
        foreach(var player in playersScenes)
        {
            GetNode(playerBoxContainerPath).AddChild(CreateButton(player));
        }
    }


    private Button CreateButton(Player player)
    {
        Button btn = playerButtonPacked.Instance<Button>();
        btn.Text = player.Name;
        btn.Connect("select_player", this, "_OnSelectPlayer");
        return btn;
    }


    private void _OnSelectPlayer(int index)
    {
        GetNode<Global>("/root/Global").SetSelectedPlayerPacked(playersScenesPacked[index]);
        GetTree().ChangeSceneTo(mainInterfacePacked);
    }



    public Godot.Collections.Array ListFilesInDiretory(String path)
    {
        var files = new Godot.Collections.Array();
        var dir = new Directory();
        dir.Open(path);
        dir.ListDirBegin();

        while (true)
        {
            var file = dir.GetNext();
            if (file == "")
                break;
            else if (!file.BeginsWith("."))
            {
                files.Add(file);
            }
        }

        dir.ListDirEnd();
        return files;
    }
}
