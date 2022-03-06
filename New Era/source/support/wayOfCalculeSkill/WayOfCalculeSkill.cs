using Godot;
using Godot.Collections;
using System;

public abstract class WayOfCalculeSkill : Godot.Object
{
    public abstract void CalculeLevelSkill(WorkTree workTree, int workIndex, int skillIndex, int level);
}