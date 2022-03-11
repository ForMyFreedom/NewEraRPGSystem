using Godot;
using System;

using Entities;

namespace Statics.Global
{
    public class Global : Node
    {
        [Export]
        private PackedScene selectedPlayerPacked;

        private Player player;


        public void SetSelectedPlayerPacked(PackedScene packed)
        {
            selectedPlayerPacked = packed;
        }


        public PackedScene GetSelectedPlayerPacked()
        {
            return selectedPlayerPacked;
        }


        public Player GetPlayer()
        {
            return player;
        }


        public void SetPlayer(Player player)
        {
            this.player = player;
        }




        //@
        public String GetSelectedSavePlayerFolder()
        {
            return MyStatic.savePath + player.GetFileName();
        }
    }
}