using Godot;
using System;

public class Global : Node
{
    [Export]
    private PackedScene selectedPlayerPacked;



    public void SetSelectedPlayerPacked(PackedScene packed)
    {
        selectedPlayerPacked = packed;
    }


    public PackedScene GetSelectedPlayerPacked()
    {
        return selectedPlayerPacked;
    }

    public String GetSelectedSavePlayerFolder()
    {
        Player player = selectedPlayerPacked.Instance<Player>();
        return MyStatic.savePath+player.Name;
    }
}
