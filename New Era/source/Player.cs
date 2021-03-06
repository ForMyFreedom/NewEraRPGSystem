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

    public void SetPlayerName(String name)
    {
        playerName = name;
    }


    public String GetCharacterName()
    {
        return characterName;
    }

    public void SetCharacterName(String name)
    {
        characterName = name;
    }


    public String GetSheetURL()
    {
        return sheetURL;
    }

    public void SetSheetURL(String URL)
    {
        sheetURL = URL;
    }


    public Texture GetPersonalBG()
    {
        return personalBG;
    }

    public void SetPersonalBG(Texture BG)
    {
        personalBG = BG;
    }


    public Color GetFirstColor()
    {
        return firstColor;
    }

    public void SetFirstColor(Color color)
    {
        firstColor = color;
    }


    public Color GetSecondColor()
    {
        return secondColor;
    }

    public void SetSecondColor(Color color)
    {
        secondColor = color;
    }




    public int GetTotalLife()
    {
        return totalFactors[(int) MyEnum.Factor.LIFE];
    }

    public void SetTotalLife(int value)
    {
        totalFactors[(int)MyEnum.Factor.LIFE] = value;
    }


    public int GetActualLife()
    {
        return actualFactors[(int)MyEnum.Factor.LIFE];
    }

    public void SetActualLife(int value)
    {
        actualFactors[(int)MyEnum.Factor.LIFE] = value;
    }


    public int GetModLife()
    {
        return modFactors[(int)MyEnum.Factor.LIFE];
    }

    public void SetModLife(int value)
    {
        modFactors[(int)MyEnum.Factor.LIFE] = value;
    }




    public int GetTotalSurge()
    {
        return totalFactors[(int)MyEnum.Factor.SURGE];
    }

    public void SetTotalSurge(int value)
    {
        totalFactors[(int)MyEnum.Factor.SURGE] = value;
    }

        
    public int GetActualSurge()
    {
        return actualFactors[(int)MyEnum.Factor.SURGE];
    }

    public void SetActualSurge(int value)
    {
        actualFactors[(int)MyEnum.Factor.SURGE] = value;
    }


    public int GetModSurge()
    {
        return modFactors[(int)MyEnum.Factor.SURGE];
    }

    public void SetModSurge(int value)
    {
        modFactors[(int)MyEnum.Factor.SURGE] = value;
    }




    public int GetTotalAgiDefense()
    {
        return totalFactors[(int)MyEnum.Factor.AGI_DEF];
    }

    public void SetTotalAgiDefense(int value)
    {
        totalFactors[(int)MyEnum.Factor.AGI_DEF] = value;
    }


    public int GetActualAgiDefense()
    {
        return actualFactors[(int)MyEnum.Factor.AGI_DEF];
    }

    public void SetActualAgiDefense(int value)
    {
        actualFactors[(int)MyEnum.Factor.AGI_DEF] = value;
    }


    public int GetModAgiDefense()
    {
        return modFactors[(int)MyEnum.Factor.AGI_DEF];
    }

    public void SetModAgiDefense(int value)
    {
        modFactors[(int)MyEnum.Factor.AGI_DEF] = value;
    }




    public int GetTotalStrDefense()
    {
        return totalFactors[(int)MyEnum.Factor.STR_DEF];
    }

    public void SetTotalStrDefense(int value)
    {
        totalFactors[(int)MyEnum.Factor.STR_DEF] = value;
    }


    public int GetActualStrDefense()
    {
        return actualFactors[(int)MyEnum.Factor.STR_DEF];
    }

    public void SetActualStrDefense(int value)
    {
        actualFactors[(int)MyEnum.Factor.STR_DEF] = value;
    }


    public int GetModStrDefense()
    {
        return modFactors[(int)MyEnum.Factor.STR_DEF];
    }

    public void SetModStrDefense(int value)
    {
        modFactors[(int)MyEnum.Factor.STR_DEF] = value;
    }
}
