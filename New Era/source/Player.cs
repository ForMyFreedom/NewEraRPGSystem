using Godot;
using Godot.Collections;
using System;

public class Player : Node, CharacterDataBank
{
    [Export]
    private PlayerSaveResource playerSaveResource;

    public void _MyRead()
    {
        if (playerSaveResource == null)
            LoadLastSaveResource();

        InjectDataInCapacities();
        CalculateWorksUp();
    }


    public void LoadLastSaveResource()
    {
        Array<String> files = FileGerenciator.ListFilesInDirectory(GetBaseSavePath());

        playerSaveResource = ResourceLoader.Load<PlayerSaveResource>(
            GetBaseSavePath()+files[files.Count - 1]
        );
    }

    public void CalculateWorksUp()
    {
        playerSaveResource.CalculateWorksUp();
    }

    public void InjectDataInCapacities()
    {
        Array<Work> works = GetWorks();
        Array<Work> updatedWorks = new Array<Work>();

        for (int i = 0; i < works.Count; i++)
        {
            works[i].InjectPlayerData(GetCapacitiesPlayerData().GetWorkPlayerData(works[i].GetEnumWork()));
            updatedWorks.Add(works[i]);

            Skill[] skillList = new Skill[works[i].GetSkillList().Length];

            for(int j = 0; j < skillList.Length; j++)
            {
                Skill skill = works[i].GetSkillList()[j];
                skill.InjectPlayerData(GetCapacitiesPlayerData().GetSkillPlayerData(works[i].GetEnumWork(), j));
                skillList[j] = skill;
            }

            updatedWorks[i].SetSkillList(skillList);
        }

        SetWorks(updatedWorks);
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

    public int GetMaximumUseOfSurge()
    {
        return playerSaveResource.GetMaximumUseOfSurge();
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

    public int GetDetermination()
    {
        return playerSaveResource.GetDetermination();
    }

    public void SetDetermination(int value)
    {
        playerSaveResource.SetDetermination(value);
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

    public int GetModDetermination()
    {
        return playerSaveResource.GetModDetermination();
    }

    public void SetModDetermination(int value)
    {
        playerSaveResource.SetModDetermination(value);
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

    public Array<Technique> GetTechniques()
    {
        return playerSaveResource.GetTechniques();
    }

    public void SetTechniques(Array<Technique> tech)
    {
        playerSaveResource.SetTechniques(tech);
    }

    public CapacitiesPlayerData GetCapacitiesPlayerData()
    {
        return playerSaveResource.GetCapacitiesPlayerData();
    }

    public void SetCapacitiesPlayerData(CapacitiesPlayerData playerData)
    {
        playerSaveResource.SetCapacitiesPlayerData(playerData);
    }

    public Array<InventoryItem> GetItens()
    {
        return playerSaveResource.GetItens();
    }

    public void SetItens(Array<InventoryItem> itens)
    {
        playerSaveResource.SetItens(itens);
    }

    public int GetWeaponIndex()
    {
        return playerSaveResource.GetWeaponIndex();
    }

    public void SetWeaponIndex(int index)
    {
        playerSaveResource.SetWeaponIndex(index);
    }

    public int GetGuard()
    {
        return playerSaveResource.GetGuard();
    }

    public void SetGuard(int guard)
    {
        playerSaveResource.SetGuard(guard);
    }

    public MyEnum.DefenseStyle GetDefenseStyle()
    {
        return playerSaveResource.GetDefenseStyle();
    }

    public void SetDefenseStyle(MyEnum.DefenseStyle style)
    {
        playerSaveResource.SetDefenseStyle(style);
    }




    public Resource GetSaveResource()
    {
        return playerSaveResource;
    }
    
    
    public string GetBaseSavePath()
    {
        return $"{MyStatic.savePath}/{Name}/";
    }

    public string GetActualSavePath()
    {
        return playerSaveResource.GetCurrentSavePath();
    }

    public int GetPrincipalWorkIndex()
    {
        return playerSaveResource.GetPrincipalWorkIndex();
    }

    public void SetPrincipalWorkIndex(int index)
    {
        playerSaveResource.SetPrincipalWorkIndex(index);
    }

    public CSharpScript GetLifeUpdaterScript()
    {
        return playerSaveResource.GetLifeUpdaterScript();
    }

    public void SetLifeUpdaterScript(CSharpScript script)
    {
        playerSaveResource.SetLifeUpdaterScript(script);
    }

    public Array<Trace> GetTraces()
    {
        return playerSaveResource.GetTraces();
    }

    public void SetTraces(Array<Trace> traces)
    {
        playerSaveResource.SetTraces(traces);
    }

    public object GetGameDataByKey(string key)
    {
        return playerSaveResource.GetGameDataByKey(key);
    }

    public void SetGameDataByKey(string key, object data)
    {
        playerSaveResource.SetGameDataByKey(key, data);
    }

    public Dictionary<string, object> GetAllGameData()
    {
        return playerSaveResource.GetAllGameData();
    }

    public void SetAllGameData(Dictionary<string, object> gameData)
    {
        playerSaveResource.SetAllGameData(gameData);
    }
}
