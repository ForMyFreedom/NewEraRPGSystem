using Godot;
using System;

public interface CharacterDataBank
{
    String GetPlayerName();
    void SetPlayerName(String name);

    String GetCharacterName();
    void SetCharacterName(String name);

    String GetSheetURL();
    void SetSheetURL(String URL);

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

    int[] GetTrainingAtributes();
    void SetTrainingAtributes(int[] value);

    int GetInspiration();
    void SetInspiration(int value);

    String GetTrivia();
    void SetTrivia(String text);
}