using Godot;
using System;

using Entities;

public class Booble : Control
{
    [Export]
    protected NodePath textureNodePath;


    public TextureRect GetTexture()
    {
        return GetNode<TextureRect>(textureNodePath);
    }

    protected MainInterface GetMain()
    {
        return (MainInterface) GetTree().CurrentScene;
    }
}
