 using Godot;
using System;

public static class RollCode
{
    public static int GetRandomBasicRoll(int value)
    {
        return RollSomeDices(value);
    }


    public static int GetRandomAdvancedRoll(int rollValue, int sumValue, int modValue=0)
    {
        int result = sumValue+modValue;
        int finalRollValue = rollValue + modValue;
        int effect = (finalRollValue > 0) ? 1 : -1;

        return result + RollSomeDices(finalRollValue, effect);
    }




    private static int RollSomeDices(int quant, int effect=1)
    {
        Random rgn = new Random();
        int result = 0;

        for (int i = 0; i < Math.Abs(quant); i++)
            result += rgn.Next(1, 7) * effect;

        return result;
    }

}