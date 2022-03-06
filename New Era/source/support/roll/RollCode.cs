 using Godot;
using System;

public static class RollCode
{
    private static Random rgn = new Random();

    public static int GetRandomCustomRoll(int dice)
    {
        return rgn.Next(1, dice + 1);
    }

    public static int GetRandomBasicRoll(int value)
    {
        return RollSomeD6(value);
    }


    public static int GetRandomAdvancedRoll(int rollValue, int sumValue, int modValue=0)
    {
        int result = sumValue+modValue;
        int finalRollValue = rollValue + modValue;
        int effect = (finalRollValue > 0) ? 1 : -1;

        return result + RollSomeD6(finalRollValue, effect);
    }




    private static int RollSomeD6(int quant, int effect=1)
    {
        int result = 0;

        for (int i = 0; i < Math.Abs(quant); i++)
            result += rgn.Next(1, 7) * effect;

        return result;
    }

}