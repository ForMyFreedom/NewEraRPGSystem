using Godot;
using Godot.Collections;
using System;

public class TechniquesTree : Tree
{
    private Array<Technique> techniques;












    public Array<Technique> GetTechniques()
    {
        return techniques;
    }

    public void SetTechniques(Array<Technique> tech)
    {
        techniques = tech;
    }
}