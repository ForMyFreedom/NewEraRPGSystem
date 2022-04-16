using Godot;
using System;

public abstract class LifeUpdaterAbstract : Godot.Object
{
    protected MainInterface main;

    public LifeUpdaterAbstract() { }
    public LifeUpdaterAbstract(MainInterface main) => this.main = main;

    public abstract void DoUpdateOfLife(int value);

}