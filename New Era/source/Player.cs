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
    private int[] totalFactors;
    [Export]
    private int[] actualFactors;
    [Export]
    private int[] modFactors;
    [Export]
    private int[] totalAtributes;
    [Export]
    private int[] modAtributes;


    public String GetPlayerName()
    {
        return playerName;
    }

    public String GetCharacterName()
    {
        return characterName;
    }

    public String GetSheetURL()
    {
        return sheetURL;
    }

    public Texture GetPersonalBG()
    {
        return personalBG;
    }

    public Color GetFirstColor()
    {
        return firstColor;
    }

    public Color GetSecondColor()
    {
        return secondColor;
    }


    public int GetTotalLife() { return totalFactors[(int) MyEnum.Factor.LIFE]; }
    public int GetActualLife() { return actualFactors[(int)MyEnum.Factor.LIFE]; }
    public int GetModLife() { return modFactors[(int)MyEnum.Factor.LIFE]; }

    public int GetTotalSurge() { return totalFactors[(int)MyEnum.Factor.SURGE]; }
    public int GetActualSurge() { return actualFactors[(int)MyEnum.Factor.SURGE]; }
    public int GetModSurge() { return modFactors[(int)MyEnum.Factor.SURGE]; }

    public int GetTotalAgiDefense() { return totalFactors[(int)MyEnum.Factor.AGI_DEF]; }
    public int GetActualAgiDefense() { return actualFactors[(int)MyEnum.Factor.AGI_DEF]; }
    public int GetModAgiDefense() { return modFactors[(int)MyEnum.Factor.AGI_DEF]; }

    public int GetTotalStrDefense() { return totalFactors[(int)MyEnum.Factor.STR_DEF]; }
    public int GetActualStrDefense() { return actualFactors[(int)MyEnum.Factor.STR_DEF]; }
    public int GetModStrDefense() { return modFactors[(int)MyEnum.Factor.STR_DEF]; }

}
