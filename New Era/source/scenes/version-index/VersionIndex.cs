using Godot;
using Godot.Collections;
using System;

using Entities;
using Statics.File;
using Statics.Global;

namespace Scenes
{
    public class VersionIndex : Control
    {
        [Export]
        private NodePath animationPlayerPath;
        [Export]
        private NodePath quantOfSavesLabelPath;

        public override void _Ready()
        {
            GetNode<AnimationPlayer>(animationPlayerPath).Play("fade-in");

            string playerFolder = GetNode<Global>("/root/Global/").GetSelectedSavePlayerFolder();

            Array<string> paths = FileGerenciator.ListFilesInDirectory(playerFolder);
            PlayerSaveResource save = ResourceLoader.Load<PlayerSaveResource>(
                playerFolder + "\\" + paths[paths.Count - 1]
            );

            GetNode<Label>(quantOfSavesLabelPath).Text = save.GetEditionIndex().ToString();
        }
    }
}