using Godot;
using System;
using System.Text;

public class MainInterface : Control
{
    [Export]
    private PackedScene playerScene;
    [Export]
    private NodePath playerNamePath;
    [Export]
    private NodePath characterNamePath;
    [Export]
    private NodePath sheetOpenButtonPath;
    [Export]
    private NodePath bgTexturePath;
    [Export]
    private NodePath shadeColorRectPath;
    [Export]
    private NodePath firstColorRectPath;
    [Export]
    private NodePath secondColorRectPath;
    [Export]
    private NodePath lifeFactorPath;
    [Export]
    private NodePath surgeFactorPath;
    [Export]
    private NodePath agiDefenseFactorPath;
    [Export]
    private NodePath strDefenseFactorPath;

    private Player player;
    private Color[] colors = new Color[2];

    public override void _Ready()
    {
        player = playerScene.Instance<Player>();
        GetNode(sheetOpenButtonPath).Connect("button_up", this, "_OnOpenSheet");
        Connect("tree_exiting", this, "RegisterAllData");
        InitializeData();
    }


    private void InitializeData()
    {
        SetPlayerName(player.GetPlayerName());
        SetCharacterName(player.GetCharacterName());

        SetBGTexture(player.GetPersonalBG());
        SetFirstColor(player.GetFirstColor());
        SetSecondColor(player.GetSecondColor());

        SetTotalLife(player.GetTotalLife());
        SetActualLife(player.GetActualLife());
        SetModLife(player.GetModLife());

        SetTotalSurge(player.GetTotalSurge());
        SetActualSurge(player.GetActualSurge());
        SetModSurge(player.GetModSurge());

        SetTotalAgilityDefense(player.GetTotalAgiDefense());
        SetActualAgilityDefense(player.GetActualAgiDefense());
        SetModAgilityDefense(player.GetModAgiDefense());

        SetTotalStrengthDefense(player.GetTotalStrDefense());
        SetActualStrengthDefense(player.GetActualStrDefense());
        SetModStrengthDefense(player.GetModStrDefense());
    }

    private void RegisterAllData()
    {
        PassAllDataToPlayer();
        var packedScene = new PackedScene();
        packedScene.Pack(player);
        ResourceSaver.Save("res://test.tscn", packedScene);
    }

    private void PassAllDataToPlayer()
    {
        //@
    }




    public void _OnOpenSheet()
    {
        OS.ShellOpen(player.GetSheetURL());
    }




    public String GetPlayerName() { return GetNode<MyLabel>(playerNamePath).GetTextData(); }
    public void SetPlayerName(String str) { GetNode<MyLabel>(playerNamePath).SetText(str); }

    public String GetCharacterName() { return GetNode<MyLabel>(characterNamePath).GetTextData(); }
    public void SetCharacterName(String str) { GetNode<MyLabel>(characterNamePath).SetText(str); }

    public Texture GetBGTexture() { return GetNode<TextureRect>(bgTexturePath).Texture; }
    public void SetBGTexture(Texture text) { GetNode<TextureRect>(bgTexturePath).Texture = text; }


    public Color GetFirstColor() { return colors[0]; }

    public void SetFirstColor(Color color)
    {
        colors[0] = color;
        SetShadeColor(color);   SetFirstColorInRect(color);
    }


    public Color GetSecondColor() { return colors[1]; }

    public void SetSecondColor(Color color)
    {
        colors[1] = color;
        SetSecondColorInRect(color);
    }


    public int GetActualLife() { return (int) GetFactorActualSpin(lifeFactorPath).Value; }
    public void SetActualLife(int value) { GetFactorActualSpin(lifeFactorPath).Value = value; }
    public void AddActualLife(int sum) { GetFactorActualSpin(lifeFactorPath).Value += sum; }

    public int GetTotalLife() { return (int)GetFactorTotalSpin(lifeFactorPath).Value; }
    public void SetTotalLife(int value) { GetFactorTotalSpin(lifeFactorPath).Value = value; }
    public void AddTotalLife(int sum) { GetFactorTotalSpin(lifeFactorPath).Value += sum; }

    public int GetModLife() { return (int)GetFactorModSpin(lifeFactorPath).Value; }
    public void SetModLife(int value) { GetFactorModSpin(lifeFactorPath).Value = value; }
    public void AddModLife(int sum) { GetFactorModSpin(lifeFactorPath).Value += sum; }



    public int GetActualSurge() { return (int)GetFactorActualSpin(surgeFactorPath).Value; }
    public void SetActualSurge(int value) { GetFactorActualSpin(surgeFactorPath).Value = value; }
    public void AddActualSurge(int sum) { GetFactorActualSpin(surgeFactorPath).Value += sum; }

    public int GetTotalSurge() { return (int)GetFactorTotalSpin(surgeFactorPath).Value; }
    public void SetTotalSurge(int value) { GetFactorTotalSpin(surgeFactorPath).Value = value; }
    public void AddTotalSurge(int sum) { GetFactorTotalSpin(surgeFactorPath).Value += sum; }

    public int GetModSurge() { return (int)GetFactorModSpin(surgeFactorPath).Value; }
    public void SetModSurge(int value) { GetFactorModSpin(surgeFactorPath).Value = value; }
    public void AddModSurge(int sum) { GetFactorModSpin(surgeFactorPath).Value += sum; }



    public int GetActualAgilityDefense() { return (int)GetFactorActualSpin(agiDefenseFactorPath).Value; }
    public void SetActualAgilityDefense(int value) { GetFactorActualSpin(agiDefenseFactorPath).Value = value; }
    public void AddActualAgilityDefense(int sum) { GetFactorActualSpin(agiDefenseFactorPath).Value += sum; }

    public int GetTotalAgilityDefense() { return (int)GetFactorTotalSpin(agiDefenseFactorPath).Value; }
    public void SetTotalAgilityDefense(int value) { GetFactorTotalSpin(agiDefenseFactorPath).Value = value; }
    public void AddTotalAgilityDefense(int sum) { GetFactorTotalSpin(agiDefenseFactorPath).Value += sum; }

    public int GetModAgilityDefense() { return (int)GetFactorModSpin(agiDefenseFactorPath).Value; }
    public void SetModAgilityDefense(int value) { GetFactorModSpin(agiDefenseFactorPath).Value = value; }
    public void AddModAgilityDefense(int sum) { GetFactorModSpin(agiDefenseFactorPath).Value += sum; }



    public int GetActualStrengthDefense() { return (int)GetFactorActualSpin(strDefenseFactorPath).Value; }
    public void SetActualStrengthDefense(int value) { GetFactorActualSpin(strDefenseFactorPath).Value = value; }
    public void AddActualStrengthDefense(int sum) { GetFactorActualSpin(strDefenseFactorPath).Value += sum; }

    public int GetTotalStrengthDefense() { return (int)GetFactorTotalSpin(strDefenseFactorPath).Value; }
    public void SetTotalStrengthDefense(int value) { GetFactorTotalSpin(strDefenseFactorPath).Value = value; }
    public void AddTotalStrengthDefense(int sum) { GetFactorTotalSpin(strDefenseFactorPath).Value += sum; }

    public int GetModStrengthDefense() { return (int)GetFactorModSpin(strDefenseFactorPath).Value; }
    public void SetModStrengthDefense(int value) { GetFactorModSpin(strDefenseFactorPath).Value = value; }
    public void AddModStrengthDefense(int sum) { GetFactorModSpin(strDefenseFactorPath).Value += sum; }





    public void SetShadeColor(Color color) { GetNode<Control>(shadeColorRectPath).Modulate = color; }
    public void SetFirstColorInRect(Color color) { GetNode<Control>(firstColorRectPath).Modulate = color; }
    public void SetSecondColorInRect(Color color) { GetNode<Control>(secondColorRectPath).Modulate = color; }



    private SpinBox GetFactorActualSpin(NodePath path)
    {
        return GetNode<Factor>(path).GetActualSpin();
    }

    private SpinBox GetFactorTotalSpin(NodePath path)
    {
        return GetNode<Factor>(path).GetTotalSpin();
    }

    private SpinBox GetFactorModSpin(NodePath path)
    {
        return GetNode<Factor>(path).GetModSpin();
    }


}

