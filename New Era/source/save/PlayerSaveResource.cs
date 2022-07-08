using Godot;
using Godot.Collections;
using System;

public class PlayerSaveResource : Resource, CharacterDataBank
{
    [Export]
    private int currentEditionIndex;

    [Export]
    private String characterName;
    [Export]
    private String playerName;
    [Export(PropertyHint.MultilineText)]
    private String trivia;

    [Export]
    private Texture personalBG;
    [Export]
    private Color firstColor;
    [Export]
    private Color secondColor;

    [Export]
    private int inspiration;
    [Export]
    private int extraDamage;

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
    [Export]
    private int[] trainingAtributes;

    [Export]
    private Array<Work> works;
    [Export]
    private Godot.Collections.Array notificationList;
    [Export]
    private Array<Array<CriticUse>> allCriticUses;
    [Export]
    private Array<Technique> allTechniques;

    [Export]
    private CapacitiesPlayerData capacitiesPlayerData;

    [Export]
    private Array<InventoryItem> itens;
    [Export]
    private int weaponIndex;
    [Export]
    private int guard;
    [Export]
    private MyEnum.DefenseStyle defenseStyle;
    [Export]
    private int principalWorkIndex;
    [Export]
    private CSharpScript lifeUpdaterScript;

    [Export]
    private Array<Trace> traces;
    [Export]
    private Dictionary<string, object> gameData;



    public int GetEditionIndex()
    {
        return currentEditionIndex;
    }

    public String GetBaseSavePath()
    {
        return $"{MyStatic.savePath}{characterName}/";
    }

    public String GetCurrentSavePath()
    {
        return GetBaseSavePath()+$"{characterName}_{GetEditionIndexString()}.tres";
    }

    private String GetEditionIndexString()
    {
        currentEditionIndex = GetLastEditionIndex();
        currentEditionIndex++;

        if (currentEditionIndex.ToString().Length == 1)
            return $"0{currentEditionIndex}";

        return currentEditionIndex.ToString();
    }

    public void CalculateWorksUp()
    {
        for (int i = 0; i < GetQuantOfWorksUp().Count; i++)
        {
            works[i].SetWorksUp(WorkUp.CalculeWorkUps(works[i].GetLevel()));
        }
    }

    public int GetLastEditionIndex()
    {
        Array<String> files = FileGerenciator.ListFilesInDirectory(GetBaseSavePath());
        PlayerSaveResource last = ResourceLoader.Load<PlayerSaveResource>(
            GetBaseSavePath()+files[files.Count - 1]
        );
        return last.GetEditionIndex();
    }

    public void AddEditionIndex()
    {
        currentEditionIndex++;
    }



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


    public Texture GetBGTexture()
    {
        return personalBG;
    }

    public void SetBGTexture(Texture BG)
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
        return totalFactors[(int)MyEnum.Factor.LIFE];
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


    public int GetMaximumUseOfSurge()
    {
        return totalAtributes[(int) MyEnum.Factor.SURGE]/MyStatic.MaximumUseSurgeCoeficient;
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

    public int GetStrength()
    {
        return totalAtributes[(int)MyEnum.Atribute.STR];
    }

    public void SetStrength(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.STR] = value;
    }

    public int GetAgility()
    {
        return totalAtributes[(int)MyEnum.Atribute.AGI];
    }

    public void SetAgility(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.AGI] = value;
    }

    public int GetSenses()
    {
        return totalAtributes[(int)MyEnum.Atribute.SEN];
    }

    public void SetSenses(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.SEN] = value;
    }

    public int GetMind()
    {
        return totalAtributes[(int)MyEnum.Atribute.MIN];
    }

    public void SetMind(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.MIN] = value;
    }

    public int GetCharisma()
    {
        return totalAtributes[(int)MyEnum.Atribute.CHA];
    }

    public void SetCharisma(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.CHA] = value;
    }

    public int GetDetermination()
    {
        return totalAtributes[(int)MyEnum.Atribute.VON];
    }

    public void SetDetermination(int value)
    {
        totalAtributes[(int)MyEnum.Atribute.VON] = value;
    }

    public int GetModStrength()
    {
        return modAtributes[(int)MyEnum.Atribute.STR];
    }

    public void SetModStrength(int value)
    {
        modAtributes[(int)MyEnum.Atribute.STR] = value;
    }

    public int GetModAgility()
    {
        return modAtributes[(int)MyEnum.Atribute.AGI];
    }

    public void SetModAgility(int value)
    {
        modAtributes[(int)MyEnum.Atribute.AGI] = value;
    }

    public int GetModSenses()
    {
        return modAtributes[(int)MyEnum.Atribute.SEN];
    }

    public void SetModSenses(int value)
    {
        modAtributes[(int)MyEnum.Atribute.SEN] = value;
    }

    public int GetModMind()
    {
        return modAtributes[(int)MyEnum.Atribute.MIN];
    }

    public void SetModMind(int value)
    {
        modAtributes[(int)MyEnum.Atribute.MIN] = value;
    }

    public int GetModCharisma()
    {
        return modAtributes[(int)MyEnum.Atribute.CHA];
    }

    public void SetModCharisma(int value)
    {
        modAtributes[(int)MyEnum.Atribute.CHA] = value;
    }

    public int GetModDetermination()
    {
        return modAtributes[(int)MyEnum.Atribute.VON];
    }

    public void SetModDetermination(int value)
    {
        modAtributes[(int)MyEnum.Atribute.VON] = value;
    }


    public Array<Work> GetWorks()
    {
        return DuplicateWork();
    }

    public void SetWorks(Array<Work> _works)
    {
        works = _works;
    }

    public Array<Array<int>> GetQuantOfWorksUp()
    {
        Array<Array<int>> worksUps = new Array<Array<int>>();
        foreach (Work work in works)
        {
            worksUps.Add(work.GetWorksUp());
        }
        return worksUps;
    }

    public void SetQuantOfWorksUp(Array<Array<int>> ups)
    {
        for (int i = 0; i < works.Count; i++)
        {
            works[i].SetWorksUp(ups[i]);
        }
    }

    public Godot.Collections.Array GetNotifications()
    {
        return notificationList;
    }

    public void SetNotifications(Godot.Collections.Array notifications)
    {
        notificationList = notifications;
    }

    public int[] GetTrainingAtributes()
    {
        return trainingAtributes;
    }

    public void SetTrainingAtributes(int[] value)
    {
        trainingAtributes = value;
    }

    public int GetInspiration()
    {
        return inspiration;
    }

    public void SetInspiration(int value)
    {
        inspiration = value;
    }

    public int GetExtraDamage()
    {
        return extraDamage;
    }

    public void SetExtraDamage(int value)
    {
        extraDamage = value;
    }

    public string GetTrivia()
    {
        return trivia;
    }

    public void SetTrivia(string text)
    {
        trivia = text;
    }

    public Array<Array<CriticUse>> GetCriticUses()
    {
        return allCriticUses;
    }

    public void SetCriticUses(Array<Array<CriticUse>> uses)
    {
        allCriticUses = uses;
    }

    public Array<Technique> GetTechniques()
    {
        return allTechniques;
    }

    public void SetTechniques(Array<Technique> tech)
    {
        allTechniques = tech;
    }

    public CapacitiesPlayerData GetCapacitiesPlayerData()
    {
        return capacitiesPlayerData;
    }

    public void SetCapacitiesPlayerData(CapacitiesPlayerData playerData)
    {
        capacitiesPlayerData = playerData;
    }

    public Array<InventoryItem> GetItens()
    {
        return DuplicateItens();
    }

    public void SetItens(Array<InventoryItem> _itens)
    {
        itens = _itens;
    }

    public int GetWeaponIndex()
    {
        return weaponIndex;
    }

    public void SetWeaponIndex(int index)
    {
        weaponIndex = index;
    }

    public int GetGuard()
    {
        return guard;
    }

    public void SetGuard(int guard)
    {
        this.guard = guard;
    }

    public MyEnum.DefenseStyle GetDefenseStyle()
    {
        return defenseStyle;
    }

    public void SetDefenseStyle(MyEnum.DefenseStyle style)
    {
        defenseStyle = style;
    }

    public int GetPrincipalWorkIndex()
    {
        return principalWorkIndex;
    }

    public void SetPrincipalWorkIndex(int index)
    {
        principalWorkIndex = index;
    }

    public CSharpScript GetLifeUpdaterScript()
    {
        return lifeUpdaterScript;
    }

    public void SetLifeUpdaterScript(CSharpScript script)
    {
        lifeUpdaterScript = script;
    }

    public Array<Trace> GetTraces()
    {
        return traces;
    }

    public void SetTraces(Array<Trace> traces)
    {
        this.traces = traces;
    }

    public object GetGameDataByKey(string key)
    {
        if (!gameData.ContainsKey(key)) return null;
        return gameData[key];
    }

    public void SetGameDataByKey(string key, object data)
    {
        gameData[key] = data;
    }

    public Dictionary<string, object> GetAllGameData()
    {
        return gameData;
    }

    public void SetAllGameData(Dictionary<string, object> gameData)
    {
        this.gameData = gameData;
    }










    private Array<Work> DuplicateWork()
    {
        Array<Work> duplicatedArray = new Array<Work>();
        for (int i = 0; i < works.Count; i++)
        {
            duplicatedArray.Add((Work)works[i].Duplicate());
            if(consumerHasData(works[i]))
                duplicatedArray[i].InjectPlayerData(works[i].GetVolatilePlayerData());
            Skill[] originalSkillList = works[i].GetSkillList();
            Skill[] duplicatedSkillList = new Skill[originalSkillList.Length];

            for (int j = 0; j < originalSkillList.Length; j++)
            {
                duplicatedSkillList[j] = (Skill)originalSkillList[j].Duplicate();
                if(consumerHasData(originalSkillList[j]))
                    duplicatedSkillList[j].InjectPlayerData(originalSkillList[j].GetVolatilePlayerData());
            }

            duplicatedArray[i].SetSkillList(duplicatedSkillList);
        }
        return duplicatedArray;
    }

    private bool consumerHasData(IPlayerDataConsumer consumer)
    {
        return consumer.GetVolatilePlayerData() != null;
    }

    private Array<InventoryItem> DuplicateItens()
    {
        Array<InventoryItem> duplicatedArray = new Array<InventoryItem>();
        for (int i = 0; i < itens.Count; i++)
        {
            duplicatedArray.Add((InventoryItem)itens[i].Duplicate());
        }
        return duplicatedArray;
    }
}
