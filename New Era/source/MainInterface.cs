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
    private NodePath lifeFactorPath;
    [Export]
    private NodePath surgeFactorPath;
    [Export]
    private NodePath agiDefenseFactorPath;
    [Export]
    private NodePath strDefenseFactorPath;

    private Player player;

    public override void _Ready()
    {
        player = playerScene.Instance<Player>();
        GetNode(sheetOpenButtonPath).Connect("button_up", this, "_OnOpenSheet");
        InitializeData();
    }

    private void InitializeData()
    {
        SetPlayerName(player.GetPlayerName());
        SetCharacterName(player.GetCharacterName());

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







    public void _OnOpenSheet()
    {
        OS.ShellOpen(player.GetSheetURL());
    }




    public String GetPlayerName() { return GetNode<MyLabel>(playerNamePath).GetTextData(); }
    public void SetPlayerName(String str) { GetNode<MyLabel>(playerNamePath).SetText(str); }

    public String GetCharacterName() { return GetNode<MyLabel>(characterNamePath).GetTextData(); }
    public void SetCharacterName(String str) { GetNode<MyLabel>(characterNamePath).SetText(str); }



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

