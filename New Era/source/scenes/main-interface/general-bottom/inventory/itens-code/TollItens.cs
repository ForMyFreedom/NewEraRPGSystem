using Godot;
using System;

using Entities;
using Statics.Enums;

public abstract class TollItens : ItemCode
{
    [Export]
    private int quality;
    [Export]
    private MyEnum.Work workEnum;
    [Export]
    private int skillIndex;
    [Export]
    private int actionIndex;

    public override void DoComportament(MainInterface main, InventoryItem item)
    {
        main.RequestSkillMechanic(workEnum, skillIndex, 3 * quality, actionIndex);
    }
}
