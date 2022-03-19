using Godot;
using System;

public abstract class LifeUpdaterFromPrincipalWork : LifeUpdaterAbstract
{
    protected int principalWorkLevel;

    public LifeUpdaterFromPrincipalWork(MainInterface main) : base(main)
    {
        principalWorkLevel = GetLevelFromPrincipalWork(main);
    }


    public override void DoUpdateOfLife(int value)
    {
        float mean = (value + principalWorkLevel) / 2.0f;

        if (mean == ((int)mean))
        {
            main.AddModLife((value-principalWorkLevel)/2);
            principalWorkLevel = value;
        }
    }

    private int GetLevelFromPrincipalWork(MainInterface main)
    {
        return main.GetWorks()[main.GetPrincipalWorkIndex()].GetLevel();
    }
}