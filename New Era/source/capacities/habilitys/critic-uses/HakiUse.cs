using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class HakiUse : CriticUse
{
    const string hakiKey = "hakiColors";

    protected abstract HakiColors[] GetHakiUseColors();

    protected int GetHakisColorRollResult(MainInterface main, int originalCritic)
    {
        HakiColors[] usedColors = GetHakiUseColors();
        IColorsData[] selectedColorsData = GetSelectedColorsData(main, usedColors);
        int originalLevel = main.GetWorkNodeByEnum(relatedWork).GetLevel();
        int levelMean = 0;

        for(int i = 0; i < selectedColorsData.Length; i++)
        {
            levelMean += selectedColorsData[i].GetColorfullHakiLevel(originalLevel);
        }

        levelMean /= selectedColorsData.Length;

        int newResult = RollCode.GetRandomAdvancedRoll(levelMean, main.GetDetermination());

        main.AddActualSurge(originalCritic/2-newResult/20);
        return newResult;
    }

    private IColorsData[] GetSelectedColorsData(MainInterface main, HakiColors[] usedColors)
    {
        dynamic allColorsData = main.GetGameDataByKey(hakiKey);
        List<ColorsData> selectedColors = new List<ColorsData>();

        foreach(ColorsData color in allColorsData)
        {
            if (usedColors.Contains(color.GetColorEnum()))
                selectedColors.Add(color);
        }

        return selectedColors.ToArray();
    }
}
