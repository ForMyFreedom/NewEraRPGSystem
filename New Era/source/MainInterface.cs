using Godot;
using Godot.Collections;
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
    private NodePath worksTreePath;
    [Export]
    private NodePath notificationPath;

    private Player player;
    private Color[] colors = new Color[2];

    public override void _Ready()
    {
        player = playerScene.Instance<Player>();
        player._Ready();
        GetNode(sheetOpenButtonPath).Connect("button_up", this, "_OnOpenSheet");
        Connect("tree_exiting", this, "RegisterAllData");
        RegistryData(player, this);
        CenterTheWindow();
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

        reciver.SetWorks(sender.GetWorks());
        reciver.SetWorksLevel(sender.GetWorksLevel());
        reciver.SetSkillsLevel(sender.GetSkillsLevel());
        reciver.SetQuantOfWorksUp(sender.GetQuantOfWorksUp());

        reciver.SetNotifications(sender.GetNotifications());
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


    public Atributo GetAtributeNodeByEnum(MyEnum.Atribute atribute)
    {
        switch (atribute)
        {
            case MyEnum.Atribute.STR:
                return GetNode<Atributo>(strAtributePath);
            case MyEnum.Atribute.AGI:
                return GetNode<Atributo>(agiAtributePath);
            case MyEnum.Atribute.SEN:
                return GetNode<Atributo>(senAtributePath);
            case MyEnum.Atribute.MIN:
                return GetNode<Atributo>(minAtributePath);
            case MyEnum.Atribute.CHA:
                return GetNode<Atributo>(chaAtributePath);
        }
        return null;
    }

    public void CreateNewNotification(String message, Texture texture = null)
    {
        GetNode<NotificationArea>(notificationPath).CreateNewNotification(message, texture);
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
        return (int)GetFactorTotalSpin(lifeFactorPath).Value;
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
        return (int)GetFactorModSpin(lifeFactorPath).Value;
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
        return (int)GetFactorActualSpin(surgeFactorPath).Value;
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
        return (int)GetFactorTotalSpin(surgeFactorPath).Value;
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
        return (int)GetFactorModSpin(surgeFactorPath).Value;
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




    public int GetActualAgiDefense()
    {
        return (int)GetFactorActualSpin(agiDefenseFactorPath).Value;
    }

    public void SetActualAgiDefense(int value)
    {
        player.SetActualAgiDefense(value);
        GetFactorActualSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddActualAgiDefense(int sum)
    {
        player.SetActualAgiDefense(player.GetActualAgiDefense() + sum);
        GetFactorActualSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetTotalAgiDefense()
    {
        return (int)GetFactorTotalSpin(agiDefenseFactorPath).Value;
    }

    public void SetTotalAgiDefense(int value)
    {
        player.SetTotalAgiDefense(value);
        GetFactorTotalSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddTotalAgiDefense(int sum)
    {
        player.SetTotalAgiDefense(player.GetTotalAgiDefense() + sum);
        GetFactorTotalSpin(agiDefenseFactorPath).Value += sum;
    }



    public int GetModAgiDefense()
    {
        return (int)GetFactorModSpin(agiDefenseFactorPath).Value;
    }

    public void SetModAgiDefense(int value)
    {
        player.SetModAgiDefense(value);
        GetFactorModSpin(agiDefenseFactorPath).Value = value;
    }

    public void AddModAgiDefense(int sum)
    {
        player.SetModAgiDefense(player.GetModAgiDefense() + sum);
        GetFactorModSpin(agiDefenseFactorPath).Value += sum;
    }




    public int GetActualStrDefense()
    {
        return (int)GetFactorActualSpin(strDefenseFactorPath).Value;
    }

    public void SetActualStrDefense(int value)
    {
        player.SetActualStrDefense(value);
        GetFactorActualSpin(strDefenseFactorPath).Value = value;
    }

    public void AddActualStrDefense(int sum)
    {
        player.SetActualStrDefense(player.GetActualStrDefense() + sum);
        GetFactorActualSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetTotalStrDefense()
    {
        return (int)GetFactorTotalSpin(strDefenseFactorPath).Value;
    }

    public void SetTotalStrDefense(int value)
    {
        player.SetTotalStrDefense(value);
        GetFactorTotalSpin(strDefenseFactorPath).Value = value;
    }

    public void AddTotalStrDefense(int sum)
    {
        player.SetTotalStrDefense(player.GetTotalStrDefense() + sum);
        GetFactorTotalSpin(strDefenseFactorPath).Value += sum;
    }



    public int GetModStrDefense()
    {
        return (int)GetFactorModSpin(strDefenseFactorPath).Value;
    }

    public void SetModStrDefense(int value)
    {
        player.SetModStrDefense(value);
        GetFactorModSpin(strDefenseFactorPath).Value = value;
    }

    public void AddModStrDefense(int sum)
    {
        player.SetModStrDefense(player.GetModStrDefense() + sum);
        GetFactorModSpin(strDefenseFactorPath).Value += sum;
    }





    public int GetStrength()
    {
        return GetAtributeMajor(strAtributePath);
    }

    public void SetStrength(int value)
    {
        player.SetStrength(value);
        SetAtributeMajor(strAtributePath, value);
    }

    public void AddStrength(int sum)
    {
        player.SetStrength(player.GetStrength()+sum);
        AddAtributeMajor(strAtributePath, sum);
    }



    public int GetAgility()
    {
        return GetAtributeMajor(agiAtributePath);
    }

    public void SetAgility(int value)
    {
        player.SetAgility(value);
        SetAtributeMajor(agiAtributePath, value);
    }

    public void AddAgility(int sum)
    {
        player.SetAgility(player.GetAgility() + sum);
        AddAtributeMajor(agiAtributePath, sum);
    }



    public int GetSenses()
    {
        return GetAtributeMajor(senAtributePath);
    }

    public void SetSenses(int value)
    {
        player.SetSenses(value);
        SetAtributeMajor(senAtributePath, value);
    }

    public void AddSenses(int sum)
    {
        player.SetSenses(player.GetSenses() + sum);
        AddAtributeMajor(senAtributePath, sum);
    }



    public int GetMind()
    {
        return GetAtributeMajor(minAtributePath);
    }

    public void SetMind(int value)
    {
        player.SetMind(value);
        SetAtributeMajor(minAtributePath, value);
    }

    public void AddMind(int sum)
    {
        player.SetMind(player.GetMind() + sum);
        AddAtributeMajor(minAtributePath, sum);
    }



    public int GetCharisma()
    {
        return GetAtributeMajor(chaAtributePath);
    }

    public void SetCharisma(int value)
    {
        player.SetCharisma(value);
        SetAtributeMajor(chaAtributePath, value);
    }

    public void AddCharisma(int sum)
    {
        player.SetCharisma(player.GetCharisma() + sum);
        AddAtributeMajor(chaAtributePath, sum);
    }





    public int GetModStrength()
    {
        return GetAtributeMod(strAtributePath);
    }

    public void SetModStrength(int value)
    {
        player.SetModStrength(value);
        SetAtributeMod(strAtributePath, value);
    }

    public void AddModStrength(int sum)
    {
        player.SetModStrength(player.GetModStrength() + sum);
        AddAtributeMod(strAtributePath, sum);
    }



    public int GetModAgility()
    {
        return GetAtributeMod(agiAtributePath);
    }

    public void SetModAgility(int value)
    {
        player.SetModAgility(value);
        SetAtributeMod(agiAtributePath, value);
    }

    public void AddModAgility(int sum)
    {
        player.SetModAgility(player.GetModAgility() + sum);
        AddAtributeMod(agiAtributePath, sum);
    }



    public int GetModSenses()
    {
        return GetAtributeMod(senAtributePath);
    }

    public void SetModSenses(int value)
    {
        player.SetModSenses(value);
        SetAtributeMod(senAtributePath, value);
    }

    public void AddModSenses(int sum)
    {
        player.SetModSenses(player.GetModSenses() + sum);
        AddAtributeMod(senAtributePath, sum);
    }



    public int GetModMind()
    {
        return GetAtributeMod(minAtributePath);
    }

    public void SetModMind(int value)
    {
        player.SetModMind(value);
        SetAtributeMod(minAtributePath, value);
    }

    public void AddModMind(int sum)
    {
        player.SetModMind(player.GetModMind() + sum);
        AddAtributeMod(minAtributePath, sum);
    }



    public int GetModCharisma()
    {
        return GetAtributeMod(chaAtributePath);
    }

    public void SetModCharisma(int value)
    {
        player.SetModCharisma(value);
        SetAtributeMod(chaAtributePath, value);
    }

    public void AddModCharisma(int sum)
    {
        player.SetModCharisma(player.GetModCharisma() + sum);
        AddAtributeMod(chaAtributePath, sum);
    }


    public Array<MyEnum.Work> GetWorks()
    {
        return GetNode<WorkTree>(worksTreePath).GetWorks();
    }

    public void SetWorks(Array<MyEnum.Work> _works)
    {
        GetNode<WorkTree>(worksTreePath).SetWorks(_works);
    }

    public int[] GetWorksLevel()
    {
        return GetNode<WorkTree>(worksTreePath).GetWorksLevel();
    }

    public void SetWorksLevel(int[] level)
    {
        GetNode<WorkTree>(worksTreePath).SetWorksLevel(level);
    }

    public int[,] GetSkillsLevel()
    {
        return GetNode<WorkTree>(worksTreePath).GetSkillLevel();
    }

    public void SetSkillsLevel(int[,] level)
    {
        GetNode<WorkTree>(worksTreePath).SetSkillLevel(level);
    }

    public Array<Array<int>> GetQuantOfWorksUp()
    {
        return GetNode<WorkTree>(worksTreePath).GetWorksUps();
    }

    public void SetQuantOfWorksUp(Array<Array<int>> ups)
    {
        GetNode<WorkTree>(worksTreePath).SetWorksUps(ups);
    }

    public Godot.Collections.Array GetNotifications()
    {
        return GetNode<NotificationArea>(notificationPath).GetNotifications();
    }

    public void SetNotifications(Godot.Collections.Array notifications)
    {
        GetNode<NotificationArea>(notificationPath).SetNotifications(notifications);
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



    private void SetAtributeMajor(NodePath path, int value)
    {
        GetNode<Atributo>(path).SetAtributeValue(value);
    }

    private void SetAtributeMod(NodePath path, int value)
    {
        GetNode<Atributo>(path).SetModValue(value);
    }

    private void AddAtributeMajor(NodePath path, int value)
    {
        SetAtributeMajor(path, value + GetAtributeMajor(path));
    }

    private void AddAtributeMod(NodePath path, int value)
    {
        SetAtributeMod(path, value + GetAtributeMod(path));
    }

    private int GetAtributeMajor(NodePath path)
    {
        return GetNode<Atributo>(path).GetAtributeValue();
    }

    private int GetAtributeMod(NodePath path)
    {
        return GetNode<Atributo>(path).GetModValue();
    }




    private void CenterTheWindow()
    {
        Vector2 screenSize = OS.GetScreenSize(0);
        screenSize.y *= 0.90f;
        Vector2 windowSize = OS.WindowSize;
        OS.WindowPosition = (screenSize - windowSize) * 0.5f;
    }


}

