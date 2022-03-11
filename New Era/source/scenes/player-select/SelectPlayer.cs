using Godot;
using Godot.Collections;
using System;

using Entities;
using Statics.File;
using Statics;

namespace Scenes
{
    public class SelectPlayer : Control
    {
        [Export]
        private NodePath playerBoxContainerPath;
        [Export]
        private PackedScene playerButtonPacked;
        [Export]
        private PackedScene mainInterfacePacked;
        [Export]
        private NodePath animationPlayerPath;

        private Godot.Collections.Array<string> playerStringPathArray;
        private Player[] playersResources;


        public override void _Ready()
        {
            LoadPlayersData();
            LoadPlayersButtons();
            MyStatic.CenterTheWindow();
            GetNode<AnimationPlayer>(animationPlayerPath).Play("fade-in");
        }


        private void LoadPlayersData()
        {
            playerStringPathArray = FileGerenciator.ListFilesInDirectory(MyStatic.savePath);
            playersResources = new Player[playerStringPathArray.Count];


            for (int i = 0; i < playerStringPathArray.Count; i++)
            {
                var allPlayerSaves = FileGerenciator.ListFilesInDirectory(
                     GetPlayerFolderPath(playerStringPathArray[i])
                );

                playersResources[i] = ResourceLoader.Load<Player>(
                    $"{GetPlayerFolderPath(playerStringPathArray[i])}" +
                    $"{GetLastSaveFromFolder(allPlayerSaves)}"
                );
            }
        }


        private void LoadPlayersButtons()
        {
            foreach (var player in playersResources)
            {
                GetNode(playerBoxContainerPath).AddChild(CreateButton(player));
            }
        }


        private Button CreateButton(Player player)
        {
            Button btn = playerButtonPacked.Instance<Button>();
            btn.Text = player.GetFileName();
            btn.Connect("select_player", this, "_OnSelectPlayer");
            return btn;
        }


        private async void _OnSelectPlayer(int index)
        {
            GetNode<AnimationPlayer>(animationPlayerPath).Play("fade-out");
            await ToSignal(GetNode<AnimationPlayer>(animationPlayerPath), "animation_finished");

            //@
            //GetNode<Global>("/root/Global").SetSelectedPlayerPacked(playersScenesPacked[index]);
            GetTree().ChangeSceneTo(mainInterfacePacked);
        }



        private string GetPlayerFolderPath(String playerName)
        {
            return $"{MyStatic.savePath}{playerName}//";
        }

        private string GetLastSaveFromFolder(Array<String> allPlayerSaves)
        {
            return allPlayerSaves[allPlayerSaves.Count - 1];
        }
    }
}