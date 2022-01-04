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




    public int GetActualLife()
    {
        return player.GetActualLife();
    }
    
    public void SetActualLife(int value)
    {
        player.SetActualLife(value);
        GetFactorActualSpin(lifeFactorPath).Value = value;
    }

    public void AddActualLife(int sum)
    {
        player.SetActualLife(player.GetActualLife() + sum);
        GetFactorActualSpin(lifeFactorPath).Value += sum;
    }



    public int GetTotalLife()
    {
        return player.GetTotalLife();
    }

    public void SetTotalLife(int value)
    {
        player.SetTotalLife(value);
        GetFactorTotalSpin(lifeFactorPath).Value = value;
    }

    public void AddTotalLife(int sum)
    {
        player.SetTotalLife(player.GetTotalLife() + sum);
        GetFactorTotalSpin(lifeFactorPath).Value += sum;
    }



    public int GetModLife()
    {
        return player.GetModLife();
    }

    public void SetModLife(int value)
    {
        player.SetModLife(value);
        GetFactorModSpin(lifeFactorPath).Value = value;
    }

    public void AddModLife(int sum)
    {
        player.SetModLife(player.GetModLife() + sum);
        GetFactorModSpin(lifeFactorPath).Value += sum;
    }




    public int GetActualSurge()
    {
        return player.GetActualSurge();
    }

    public void SetActualSurge(int value)
    {
        player.SetActualSurge(value);
        GetFactorActualSpin(surgeFactorPath).Value = value;
    }

    public void AddActualSurge(int sum)
    {
        player.SetActualSurge(player.GetActualSurge() + sum);
        GetFactorActualSpin(surgeFactorPath).Value += sum;
    }



    public int GetTotalSurge()
    {
        return player.GetTotalSurge();
    }

    public void SetTotalSurge(int value)
    {
        player.SetTotalSurge(value);
        GetFactorTotalSpin(surgeFactorPath).Value = value;
    }

    public void AddTotalSurge(int sum)
    {
        player.SetTotalSurge(player.GetTotalSurge() + sum);
        GetFactorTotalSpin(surgeFactorPath).Value += sum;
    }



    public int GetModSurge()
    {
        return player.GetModSurge();
    }

    public void SetModSurge(int value)
    {
        player.SetModSurge(value);
        GetFactorModSpin(surgeFactorPath).Value = value;
    }

    public void AddModSurge(int sum)
    {
        player.SetModSurge(player.GetModSurge() + sum);
        GetFactorModSpin(surgeFactorPath).Value += sum;
    }




    public int GetActualAgilityDefense()
    {
        return player.GetActualAgiDefense();
    }

    public void SetActualAgilityDefense(int value)
    {
        player.SetActualAgiDefense(value);
        GetFactorActualSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddActualAgilityDefense(int sum)
    {
        player.SetActualAgiDefense(player.GetActualAgiDefense() + sum);
        GetFactorActualSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetTotalAgilityDefense()
    {
        return player.GetTotalAgiDefense();
    }

    public void SetTotalAgilityDefense(int value)
    {
        player.SetTotalAgiDefense(value);
        GetFactorTotalSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddTotalAgilityDefense(int sum)
    {
        player.SetTotalAgiDefense(player.GetTotalAgiDefense() + sum);
        GetFactorTotalSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetModAgilityDefense()
    {
        return player.GetModAgiDefense();
    }

    public void SetModAgilityDefense(int value)
    {
        player.SetModAgiDefense(value);
        GetFactorModSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddModAgilityDefense(int sum)
    {
        player.SetModAgiDefense(player.GetModAgiDefense() + sum);
        GetFactorModSpin(agiDefenseFactorPath).Value += sum;
    }




    public int GetActualStrengthDefense()
    {
        return player.GetActualStrDefense();
    }

    public void SetActualStrengthDefense(int value)
    {
        player.SetActualStrDefense(value);
        GetFactorActualSpin(strDefenseFactorPath).Value = value;
    }

    public void AddActualStrengthDefense(int sum)
    {
        player.SetActualStrDefense(player.GetActualStrDefense() + sum);
        GetFactorActualSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetTotalStrengthDefense()
    {
        return player.GetTotalStrDefense();
    }

    public void SetTotalStrengthDefense(int value)
    {
        player.SetTotalStrDefense(value);
        GetFactorTotalSpin(strDefenseFactorPath).Value = value;
    }

    public void AddTotalStrengthDefense(int sum)
    {
        player.SetTotalStrDefense(player.GetTotalStrDefense() + sum);
        GetFactorTotalSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetModStrengthDefense()
    {
        return player.GetModStrDefense();
    }

    public void SetModStrengthDefense(int value)
    {
        player.SetModStrDefense(value);
        GetFactorModSpin(strDefenseFactorPath).Value = value;
    }

    public void AddModStrengthDefense(int sum)
    {
        player.SetModStrDefense(player.GetModStrDefense() + sum);
        GetFactorModSpin(strDefenseFactorPath).Value += sum;
    }





    public int GetStrength()
    {
        return (int) GetAtributeMajorSpin(strAtributePath).Value;
    }

    public void SetStrength(int value)
    {
        player.SetStrength(value);
        GetAtributeMajorSpin(strAtributePath).Value = value;
    }

    public void AddStrength(int sum)
    {
        player.SetStrength(player.GetStrength()+sum);
        GetAtributeMajorSpin(strAtributePath).Value += sum;
    }



    public int GetAgility()
    {
        return (int) GetAtributeMajorSpin(agiAtributePath).Value;
    }

    public void SetAgility(int value)
    {
        player.SetAgility(value);
        GetAtributeMajorSpin(agiAtributePath).Value = value;
    }

    public void AddAgility(int sum)
    {
        player.SetAgility(player.GetAgility() + sum);
        GetAtributeMajorSpin(agiAtributePath).Value += sum;
    }



    public int GetSenses()
    {
        return (int) GetAtributeMajorSpin(senAtributePath).Value;
    }

    public void SetSenses(int value)
    {
        player.SetSenses(value);
        GetAtributeMajorSpin(senAtributePath).Value = value;
    }

    public void AddSenses(int sum)
    {
        player.SetSenses(player.GetSenses() + sum);
        GetAtributeMajorSpin(senAtributePath).Value += sum;
    }



    public int GetMind()
    {
        return (int) GetAtributeMajorSpin(minAtributePath).Value;
    }

    public void SetMind(int value)
    {
        player.SetMind(value);
        GetAtributeMajorSpin(minAtributePath).Value = value;
    }

    public void AddMind(int sum)
    {
        player.SetMind(player.GetMind() + sum);
        GetAtributeMajorSpin(minAtributePath).Value += sum;
    }



    public int GetCharisma()
    {
        return (int) GetAtributeMajorSpin(chaAtributePath).Value;
    }

    public void SetCharisma(int value)
    {
        player.SetCharisma(value);
        GetAtributeMajorSpin(chaAtributePath).Value = value;
    }

    public void AddCharisma(int sum)
    {
        player.SetCharisma(player.GetCharisma() + sum);
        GetAtributeMajorSpin(chaAtributePath).Value += sum;
    }





    public int GetModStrength()
    {
        return (int)GetAtributeModSpin(strAtributePath).Value;
    }

    public void SetModStrength(int value)
    {
        player.SetModStrength(value);
        GetAtributeModSpin(strAtributePath).Value = value;
    }

    public void AddModStrength(int sum)
    {
        player.SetModStrength(player.GetModStrength() + sum);
        GetAtributeModSpin(strAtributePath).Value += sum;
    }



    public int GetModAgility()
    {
        return (int) GetAtributeModSpin(agiAtributePath).Value;
    }

    public void SetModAgility(int value)
    {
        player.SetModAgility(value);
        GetAtributeModSpin(agiAtributePath).Value = value;
    }

    public void AddModAgility(int sum)
    {
        player.SetModAgility(player.GetModAgility() + sum);
        GetAtributeModSpin(agiAtributePath).Value += sum;
    }



    public int GetModSenses()
    {
        return (int) GetAtributeModSpin(senAtributePath).Value;
    }

    public void SetModSenses(int value)
    {
        player.SetModSenses(value);
        GetAtributeModSpin(senAtributePath).Value = value;
    }

    public void AddModSenses(int sum)
    {
        player.SetModSenses(player.GetModSenses() + sum);
        GetAtributeModSpin(senAtributePath).Value += sum;
    }



    public int GetModMind()
    {
        return (int) GetAtributeModSpin(minAtributePath).Value;
    }

    public void SetModMind(int value)
    {
        player.SetModMind(value);
        GetAtributeModSpin(minAtributePath).Value = value;
    }

    public void AddModMind(int sum)
    {
        player.SetModMind(player.GetModMind() + sum);
        GetAtributeModSpin(minAtributePath).Value += sum;
    }



    public int GetModCharisma()
    {
        return (int) GetAtributeModSpin(chaAtributePath).Value;
    }

    public void SetModCharisma(int value)
    {
        player.SetModCharisma(value);
        GetAtributeModSpin(chaAtributePath).Value = value;
    }

    public void AddModCharisma(int sum)
    {
        player.SetModCharisma(player.GetModCharisma() + sum);
        GetAtributeModSpin(chaAtributePath).Value += sum;
    }








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



    private SpinBox GetAtributeMajorSpin(NodePath path)
    {
        return GetNode<Atribute>(path).GetMajorSpin();
    }

    private SpinBox GetAtributeModSpin(NodePath path)
    {
        return GetNode<Atribute>(path).GetModSpin();
    }
}

