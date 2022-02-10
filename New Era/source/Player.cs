using Godot;
using Godot.Collections;
using System;

public class Player : Node, CharacterDataBank
{
    [Export]
    private PlayerSaveResource playerSaveResource;
    private static int maxSkill = 3; //@

    public override void _Ready()
    {
        if (playerSaveResource == null)
            LoadLastSaveResource();
        else
            LoadDefinedSaveResource();

        CalculateWorksUp();
    }


    public void LoadLastSaveResource()
    {
        Array<String> files = FileGerenciator.ListFilesInDirectory(GetBaseSavePath());
        playerSaveResource = ResourceLoader.Load<PlayerSaveResource>(
            GetBaseSavePath()+files[files.Count - 1]
        );
    }

    public void LoadDefinedSaveResource()
    {
        //@?
    }

    public void CalculateWorksUp()
    {
        playerSaveResource.CalculateWorksUp();
    }





    public string GetPlayerName()
    {
        return playerSaveResource.GetPlayerName();
    }

    public void SetPlayerName(string name)
    {
        playerSaveResource.SetPlayerName(name);
    }

    public string GetCharacterName()
    {
        return playerSaveResource.GetCharacterName();
    }

    public void SetCharacterName(string name)
    {
        playerSaveResource.SetCharacterName(name);
    }

    public Texture GetBGTexture()
    {
        return playerSaveResource.GetBGTexture();
    }

    public void SetBGTexture(Texture BG)
    {
        playerSaveResource.SetBGTexture(BG);
    }

    public Color GetFirstColor()
    {
        return playerSaveResource.GetFirstColor();
    }

    public void SetFirstColor(Color color)
    {
        playerSaveResource.SetFirstColor(color);
    }

    public Color GetSecondColor()
    {
        return playerSaveResource.GetSecondColor();
    }

    public void SetSecondColor(Color color)
    {
        playerSaveResource.SetSecondColor(color);
    }

    public int GetTotalLife()
    {
        return playerSaveResource.GetTotalLife();
    }

    public void SetTotalLife(int value)
    {
        playerSaveResource.SetTotalLife(value);
    }

    public int GetActualLife()
    {
        return playerSaveResource.GetActualLife();
    }

    public void SetActualLife(int value)
    {
        playerSaveResource.SetActualLife(value);
    }

    public int GetModLife()
    {
        return playerSaveResource.GetModLife();
    }

    public void SetModLife(int value)
    {
        playerSaveResource.SetModLife(value);
    }

    public int GetTotalSurge()
    {
        return playerSaveResource.GetTotalSurge();
    }

    public void SetTotalSurge(int value)
    {
        playerSaveResource.SetTotalSurge(value);
    }

    public int GetActualSurge()
    {
        return playerSaveResource.GetActualSurge();
    }

    public void SetActualSurge(int value)
    {
        playerSaveResource.SetActualSurge(value);
    }

    public int GetModSurge()
    {
        return playerSaveResource.GetModSurge();
    }

    public void SetModSurge(int value)
    {
        playerSaveResource.SetModSurge(value);
    }

    public int GetTotalAgiDefense()
    {
        return playerSaveResource.GetTotalAgiDefense();
    }

    public void SetTotalAgiDefense(int value)
    {
        playerSaveResource.SetTotalAgiDefense(value);
    }

    public int GetActualAgiDefense()
    {
        return playerSaveResource.GetActualAgiDefense();
    }

    public void SetActualAgiDefense(int value)
    {
        playerSaveResource.SetActualAgiDefense(value);
    }

    public int GetModAgiDefense()
    {
        return playerSaveResource.GetModAgiDefense();
    }

    public void SetModAgiDefense(int value)
    {
        playerSaveResource.SetModAgiDefense(value);
    }

    public int GetTotalStrDefense()
    {
        return playerSaveResource.GetTotalStrDefense();
    }

    public void SetTotalStrDefense(int value)
    {
        playerSaveResource.SetTotalStrDefense(value);
    }

    public int GetActualStrDefense()
    {
        return playerSaveResource.GetActualStrDefense();
    }

    public void SetActualStrDefense(int value)
    {
        playerSaveResource.SetActualStrDefense(value);
    }

    public int GetModStrDefense()
    {
        return playerSaveResource.GetModStrDefense();
    }

    public void SetModStrDefense(int value)
    {
        playerSaveResource.SetModStrDefense(value);
    }

    public int GetStrength()
    {
        return playerSaveResource.GetStrength();
    }

    public void SetStrength(int value)
    {
        playerSaveResource.SetStrength(value);
    }

    public int GetAgility()
    {
        return playerSaveResource.GetAgility();
    }

    public void SetAgility(int value)
    {
        playerSaveResource.SetAgility(value);
    }

    public int GetSenses()
    {
        return playerSaveResource.GetSenses();
    }

    public void SetSenses(int value)
    {
        playerSaveResource.SetSenses(value);
    }

    public int GetMind()
    {
        return playerSaveResource.GetMind();
    }

    public void SetMind(int value)
    {
        playerSaveResource.SetMind(value);
    }

    public int GetCharisma()
    {
        return playerSaveResource.GetCharisma();
    }

    public void SetCharisma(int value)
    {
        playerSaveResource.SetCharisma(value);
    }

    public int GetModStrength()
    {
        return playerSaveResource.GetModStrength();
    }

    public void SetModStrength(int value)
    {
        playerSaveResource.SetModStrength(value);
    }

    public int GetModAgility()
    {
        return playerSaveResource.GetModAgility();
    }

    public void SetModAgility(int value)
    {
        playerSaveResource.SetModAgility(value);
    }

    public int GetModSenses()
    {
        return playerSaveResource.GetModSenses();
    }

    public void SetModSenses(int value)
    {
        playerSaveResource.SetModSenses(value);
    }

    public int GetModMind()
    {
        return playerSaveResource.GetModMind();
    }

    public void SetModMind(int value)
    {
        playerSaveResource.SetModMind(value);
    }

    public int GetModCharisma()
    {
        return playerSaveResource.GetModCharisma();
    }

    public void SetModCharisma(int value)
    {
        playerSaveResource.SetModCharisma(value);
    }

    public Array<Work> GetWorks()
    {
        return playerSaveResource.GetWorks();
    }

    public void SetWorks(Array<Work> _works)
    {
        playerSaveResource.SetWorks(_works);
    }

    public Godot.Collections.Array GetNotifications()
    {
        return playerSaveResource.GetNotifications();
    }

    public void SetNotifications(Godot.Collections.Array notifications)
    {
        playerSaveResource.SetNotifications(notifications);
    }

    public int[] GetTrainingAtributes()
    {
        return playerSaveResource.GetTrainingAtributes();
    }

    public void SetTrainingAtributes(int[] value)
    {
        playerSaveResource.SetTrainingAtributes(value);
    }

    public int GetInspiration()
    {
        return playerSaveResource.GetInspiration();
    }

    public void SetInspiration(int value)
    {
        playerSaveResource.SetInspiration(value);
    }

    public int GetExtraDamage()
    {
        return playerSaveResource.GetExtraDamage();
    }

    public void SetExtraDamage(int value)
    {
        playerSaveResource.SetExtraDamage(value);
    }

    public string GetTrivia()
    {
        return playerSaveResource.GetTrivia();
    }

    public void SetTrivia(string text)
    {
        playerSaveResource.SetTrivia(text);
    }

    public Array<Array<CriticUse>> GetCriticUses()
    {
        return playerSaveResource.GetCriticUses();
    }

    public void SetCriticUses(Array<Array<CriticUse>> uses)
    {
        playerSaveResource.SetCriticUses(uses);
    }

    public Array<int> GetTechniques()
    {
        return playerSaveResource.GetTechniques();
    }

    public void SetTechniques(Array<int> tech)
    {
        playerSaveResource.SetTechniques(tech);
    }




    public void PrepareSave()
    {
        playerSaveResource.AddEditionIndex();
    }


    public Resource GetSaveResource()
    {
        return playerSaveResource;
    }
    
    
    public string GetBaseSavePath()
    {
        return $"{MyEnum.savePath}/{Name}/";
    }

    public string GetActualSavePath()
    {
        return playerSaveResource.GetCurrentSavePath();
    }

}
