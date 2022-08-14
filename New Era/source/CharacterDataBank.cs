using Godot;
using Godot.Collections;
using System;

public interface CharacterDataBank
{
    String GetPlayerName();
    void SetPlayerName(String name);

    String GetCharacterName();
    void SetCharacterName(String name);

    Texture GetBGTexture();
    void SetBGTexture(Texture BG);

    Color GetFirstColor();
    void SetFirstColor(Color color);

    Color GetSecondColor();
    void SetSecondColor(Color color);

    int GetTotalLife();
    void SetTotalLife(int value);

    int GetActualLife();
    void SetActualLife(int value);

    int GetModLife();
    void SetModLife(int value);

    int GetTotalSurge();
    void SetTotalSurge(int value);

    int GetMaximumUseOfSurge();

    int GetActualSurge();
    void SetActualSurge(int value);

    int GetModSurge();
    void SetModSurge(int value);

    int GetTotalAgiDefense();
    void SetTotalAgiDefense(int value);

    int GetActualAgiDefense();
    void SetActualAgiDefense(int value);

    int GetModAgiDefense();
    void SetModAgiDefense(int value);

    int GetTotalStrDefense();
    void SetTotalStrDefense(int value);

    int GetActualStrDefense();
    void SetActualStrDefense(int value);

    int GetModStrDefense();
    void SetModStrDefense(int value);

    int GetStrength();
    void SetStrength(int value);

    int GetAgility();
    void SetAgility(int value);

    int GetSenses();
    void SetSenses(int value);

    int GetMind();
    void SetMind(int value);

    int GetCharisma();
    void SetCharisma(int value);

    int GetDetermination();
    void SetDetermination(int value);

    int GetModStrength();
    void SetModStrength(int value);

    int GetModAgility();
    void SetModAgility(int value);

    int GetModSenses();
    void SetModSenses(int value);

    int GetModMind();
    void SetModMind(int value);

    int GetModCharisma();
    void SetModCharisma(int value);

    int GetModDetermination();
    void SetModDetermination(int value);

    Array<Work> GetWorks();
    void SetWorks(Array<Work> _works);

    Godot.Collections.Array GetNotifications();
    void SetNotifications(Godot.Collections.Array notifications);

    int[] GetTrainingAtributes();
    void SetTrainingAtributes(int[] value);

    int GetInspiration();
    void SetInspiration(int value);

    int GetExtraDamage();
    void SetExtraDamage(int value);

    String GetTrivia();
    void SetTrivia(String text);

    String GetSencienceText();
    void SetSencienceText(String text);

    Array<Array<CriticUse>> GetCriticUses();
    void SetCriticUses(Array<Array<CriticUse>> uses);

    Array<Technique> GetTechniques();
    void SetTechniques(Array<Technique> tech);

    CapacitiesPlayerData GetCapacitiesPlayerData();
    void SetCapacitiesPlayerData(CapacitiesPlayerData capacitiesPlayerData);

    Array<InventoryItem> GetItens();
    void SetItens(Array<InventoryItem> itens);

    int GetWeaponIndex();
    void SetWeaponIndex(int index);

    int GetGuard();
    void SetGuard(int guard);

    MyEnum.DefenseStyle GetDefenseStyle();
    void SetDefenseStyle(MyEnum.DefenseStyle style);

    int GetPrincipalWorkIndex();
    void SetPrincipalWorkIndex(int index);

    CSharpScript GetLifeUpdaterScript();
    void SetLifeUpdaterScript(CSharpScript script);

    Array<Trace> GetTraces();
    void SetTraces(Array<Trace> traces);

    object GetGameDataByKey(string key);
    void SetGameDataByKey(string key, object data);
    Dictionary<string, object> GetAllGameData();
    void SetAllGameData(Dictionary<string, object> gameData);
}