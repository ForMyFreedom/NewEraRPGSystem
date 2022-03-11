using Godot;
using System;

using Statics.Enums;

public class DefenseBooble : Booble
{
    [Export]
    private Texture agiTexture;
    [Export]
    private Texture strTexture;

    private MyEnum.DefenseStyle defenseStyle;

    public void InvertTexture()
    {
        ChangeDefenseStyle(
            (defenseStyle == MyEnum.DefenseStyle.AgiDefense) ? 
            MyEnum.DefenseStyle.StrDefense : MyEnum.DefenseStyle.AgiDefense
        );
    }

    public void ChangeDefenseStyle(MyEnum.DefenseStyle style)
    {
        SetDefenseStyle(style);
        UpdateTexture();
        UpdateGuard();
        GetMain().SetDefenseStyle(defenseStyle);
    }

    public void UpdateTexture()
    {
        if (defenseStyle == MyEnum.DefenseStyle.StrDefense)
            GetNode<TextureRect>(textureNodePath).Texture = strTexture;
        else
            GetNode<TextureRect>(textureNodePath).Texture = agiTexture;
    }

    private void UpdateGuard()
    {
        int mod = (defenseStyle == MyEnum.DefenseStyle.StrDefense) ? 1 : -1;
        GetMain().AddGuard(mod * GetMain().GetStrength()/2);
    }


    public MyEnum.DefenseStyle GetDefenseStyle()
    {
        return defenseStyle;
    }

    public void SetDefenseStyle(MyEnum.DefenseStyle style)
    {
        defenseStyle = style;
        UpdateTexture();
    }
}
