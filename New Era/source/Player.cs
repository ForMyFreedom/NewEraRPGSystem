using Godot;
using System;

public class Player : Node
{
    [Export]
    private String playerName;
    [Export]
    private String characterName;
    
    [Export]
    private String sheetURL;
    [Export]
    private Texture personalBG;
    [Export]
    private Color firstColor;
    [Export]
    private Color secondColor;
    
    [Export]
    private int totalFactors;
    [Export]
    private int actualFactors;
    [Export]
    private int[] totalAtributes;
    [Export]
    private int[] actualAtributes;



    public override void _Ready()
    {
        
    }


    public String GetSheetURL()
    {
        return sheetURL;
    }
}
