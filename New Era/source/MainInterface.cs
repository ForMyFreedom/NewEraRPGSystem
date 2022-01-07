using Godot;
using System;
using System.Text;

public class MainInterface : Control, CharacterDataBank
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
    [Export]
    private NodePath strAtributePath;
    [Export]
    private NodePath agiAtributePath;
    [Export]
    private NodePath senAtributePath;
    [Export]
    private NodePath minAtributePath;
    [Export]
    private NodePath chaAtributePath;
    [Export]
    private NodePath inspirationSpinPath;

    private Player player;
    private Color[] colors = new Color[2];

    public override void _Ready()
    {
        player = playerScene.Instance<Player>();
        GetNode(sheetOpenButtonPath).Connect("button_up", this, "_OnOpenSheet");
        Connect("tree_exiting", this, "RegisterAllData");
        RegistryData(player, this);
    }


    private void RegistryData(CharacterDataBank sender, CharacterDataBank reciver)
    {
        reciver.SetPlayerName(sender.GetPlayerName());
        reciver.SetCharacterName(sender.GetCharacterName());

        reciver.SetBGTexture(sender.GetBGTexture());
        reciver.SetFirstColor(sender.GetFirstColor());
        reciver.SetSecondColor(sender.GetSecondColor());

        reciver.SetTotalLife(sender.GetTotalLife());
        reciver.SetActualLife(sender.GetActualLife());
        reciver.SetModLife(sender.GetModLife());

        reciver.SetTotalSurge(sender.GetTotalSurge());
        reciver.SetActualSurge(sender.GetActualSurge());
        reciver.SetModSurge(sender.GetModSurge());

        reciver.SetTotalAgiDefense(sender.GetTotalAgiDefense());
        reciver.SetActualAgiDefense(sender.GetActualAgiDefense());
        reciver.SetModAgiDefense(sender.GetModAgiDefense());

        reciver.SetTotalStrDefense(sender.GetTotalStrDefense());
        reciver.SetActualStrDefense(sender.GetActualStrDefense());
        reciver.SetModStrDefense(sender.GetModStrDefense());

        reciver.SetStrength(sender.GetStrength());
        reciver.SetAgility(sender.GetAgility());
        reciver.SetMind(sender.GetMind());
        reciver.SetSenses(sender.GetSenses());
        reciver.SetCharisma(sender.GetCharisma());

        reciver.SetModStrength(sender.GetModStrength());
        reciver.SetModAgility(sender.GetModAgility());
        reciver.SetModMind(sender.GetModMind());
        reciver.SetModSenses(sender.GetModSenses());
        reciver.SetModCharisma(sender.GetModCharisma());

        reciver.SetInspiration(sender.GetInspiration());
    }

    private void RegisterAllData()
    {
        RegistryData(this, player);
        var packedScene = new PackedScene();
        packedScene.Pack(player);
        ResourceSaver.Save(playerScene.ResourcePath, packedScene);
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

    public String GetSheetURL() { return player.GetSheetURL(); }
    public void SetSheetURL(String URL) { player.SetSheetURL(URL); }


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
        return (int) GetFactorActualSpin(lifeFactorPath).Value;
    }
    
    public void SetActualLife(int value)
    {
        GetFactorActualSpin(lifeFactorPath).Value = value;
    }

    public void AddActualLife(int sum)
    {
        GetFactorActualSpin(lifeFactorPath).Value += sum;
    }



    public int GetTotalLife()
    {
        return (int)GetFactorTotalSpin(lifeFactorPath).Value;
    }

    public void SetTotalLife(int value)
    {
        GetFactorTotalSpin(lifeFactorPath).Value = value;
    }

    public void AddTotalLife(int sum)
    {
        GetFactorTotalSpin(lifeFactorPath).Value += sum;
    }



    public int GetModLife()
    {
        return (int)GetFactorModSpin(lifeFactorPath).Value;
    }

    public void SetModLife(int value)
    {
        GetFactorModSpin(lifeFactorPath).Value = value;
    }

    public void AddModLife(int sum)
    {
        GetFactorModSpin(lifeFactorPath).Value += sum;
    }




    public int GetActualSurge()
    {
        return (int)GetFactorActualSpin(surgeFactorPath).Value;
    }

    public void SetActualSurge(int value)
    {
        GetFactorActualSpin(surgeFactorPath).Value = value;
    }

    public void AddActualSurge(int sum)
    {
        GetFactorActualSpin(surgeFactorPath).Value += sum;
    }



    public int GetTotalSurge()
    {
        return (int)GetFactorTotalSpin(surgeFactorPath).Value;
    }

    public void SetTotalSurge(int value)
    {
        GetFactorTotalSpin(surgeFactorPath).Value = value;
    }

    public void AddTotalSurge(int sum)
    {
        GetFactorTotalSpin(surgeFactorPath).Value += sum;
    }



    public int GetModSurge()
    {
        return (int)GetFactorModSpin(surgeFactorPath).Value;
    }

    public void SetModSurge(int value)
    {
        GetFactorModSpin(surgeFactorPath).Value = value;
    }

    public void AddModSurge(int sum)
    {
        GetFactorModSpin(surgeFactorPath).Value += sum;
    }




    public int GetActualAgiDefense()
    {
        return (int)GetFactorActualSpin(agiDefenseFactorPath).Value;
    }

    public void SetActualAgiDefense(int value)
    {
        GetFactorActualSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddActualAgiDefense(int sum)
    {
        GetFactorActualSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetTotalAgiDefense()
    {
        return (int)GetFactorTotalSpin(agiDefenseFactorPath).Value;
    }

    public void SetTotalAgiDefense(int value)
    {
        GetFactorTotalSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddTotalAgiDefense(int sum)
    {
        GetFactorTotalSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetModAgiDefense()
    {
        return (int)GetFactorModSpin(agiDefenseFactorPath).Value;
    }

    public void SetModAgiDefense(int value)
    {
        GetFactorModSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddModAgiDefense(int sum)
    {
        GetFactorModSpin(agiDefenseFactorPath).Value += sum;
    }




    public int GetActualStrDefense()
    {
        return (int)GetFactorActualSpin(strDefenseFactorPath).Value;
    }

    public void SetActualStrDefense(int value)
    {
        GetFactorActualSpin(strDefenseFactorPath).Value = value;
    }

    public void AddActualStrDefense(int sum)
    {
        GetFactorActualSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetTotalStrDefense()
    {
        return (int)GetFactorTotalSpin(strDefenseFactorPath).Value;
    }

    public void SetTotalStrDefense(int value)
    {
        GetFactorTotalSpin(strDefenseFactorPath).Value = value;
    }

    public void AddTotalStrDefense(int sum)
    {
        GetFactorTotalSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetModStrDefense()
    {
        return (int)GetFactorModSpin(strDefenseFactorPath).Value;
    }

    public void SetModStrDefense(int value)
    {
        GetFactorModSpin(strDefenseFactorPath).Value = value;
    }

    public void AddModStrDefense(int sum)
    {
        GetFactorModSpin(strDefenseFactorPath).Value += sum;
    }





    public int GetStrength()
    {
        return (int) GetAtributeMajorSpin(strAtributePath).Value;
    }

    public void SetStrength(int value)
    {
        GetAtributeMajorSpin(strAtributePath).Value = value;
    }

    public void AddStrength(int sum)
    {
        GetAtributeMajorSpin(strAtributePath).Value += sum;
    }



    public int GetAgility()
    {
        return (int) GetAtributeMajorSpin(agiAtributePath).Value;
    }

    public void SetAgility(int value)
    {
        GetAtributeMajorSpin(agiAtributePath).Value = value;
    }

    public void AddAgility(int sum)
    {
        GetAtributeMajorSpin(agiAtributePath).Value += sum;
    }



    public int GetSenses()
    {
        return (int) GetAtributeMajorSpin(senAtributePath).Value;
    }

    public void SetSenses(int value)
    {
        GetAtributeMajorSpin(senAtributePath).Value = value;
    }

    public void AddSenses(int sum)
    {
        GetAtributeMajorSpin(senAtributePath).Value += sum;
    }



    public int GetMind()
    {
        return (int) GetAtributeMajorSpin(minAtributePath).Value;
    }

    public void SetMind(int value)
    {
        GetAtributeMajorSpin(minAtributePath).Value = value;
    }

    public void AddMind(int sum)
    {
        GetAtributeMajorSpin(minAtributePath).Value += sum;
    }



    public int GetCharisma()
    {
        return (int) GetAtributeMajorSpin(chaAtributePath).Value;
    }

    public void SetCharisma(int value)
    {
        GetAtributeMajorSpin(chaAtributePath).Value = value;
    }

    public void AddCharisma(int sum)
    {
        GetAtributeMajorSpin(chaAtributePath).Value += sum;
    }





    public int GetModStrength()
    {
        return (int)GetAtributeModSpin(strAtributePath).Value;
    }

    public void SetModStrength(int value)
    {
        GetAtributeModSpin(strAtributePath).Value = value;
    }

    public void AddModStrength(int sum)
    {
        GetAtributeModSpin(strAtributePath).Value += sum;
    }



    public int GetModAgility()
    {
        return (int) GetAtributeModSpin(agiAtributePath).Value;
    }

    public void SetModAgility(int value)
    {
        GetAtributeModSpin(agiAtributePath).Value = value;
    }

    public void AddModAgility(int sum)
    {
        GetAtributeModSpin(agiAtributePath).Value += sum;
    }



    public int GetModSenses()
    {
        return (int) GetAtributeModSpin(senAtributePath).Value;
    }

    public void SetModSenses(int value)
    {
        GetAtributeModSpin(senAtributePath).Value = value;
    }

    public void AddModSenses(int sum)
    {
        GetAtributeModSpin(senAtributePath).Value += sum;
    }



    public int GetModMind()
    {
        return (int) GetAtributeModSpin(minAtributePath).Value;
    }

    public void SetModMind(int value)
    {
        GetAtributeModSpin(minAtributePath).Value = value;
    }

    public void AddModMind(int sum)
    {
        GetAtributeModSpin(minAtributePath).Value += sum;
    }



    public int GetModCharisma()
    {
        return (int) GetAtributeModSpin(chaAtributePath).Value;
    }

    public void SetModCharisma(int value)
    {
        GetAtributeModSpin(chaAtributePath).Value = value;
    }

    public void AddModCharisma(int sum)
    {
        GetAtributeModSpin(chaAtributePath).Value += sum;
    }



    public int GetInspiration()
    {
        return (int) GetNode<SpinBox>(inspirationSpinPath).Value;
    }

    public void SetInspiration(int value)
    {
        GetNode<SpinBox>(inspirationSpinPath).Value = value;
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

