using Godot;
using Godot.Collections;
using System;

public class WorkUp
{
    private static int[] upProgression = new[] { 5, 10, 20, 50 };

    public static Array<int> CalculeWorkUps(int value)
    {
        Array<int> newWorkUps = new Array<int>(0,0,0,0);

        for (int i = 0; i < upProgression.Length; i++)
        {
            int currentValue = value;
            while (currentValue >= upProgression[i])
            {
                currentValue -= upProgression[i];
                newWorkUps[i]++;
            }
        }

        return newWorkUps;
    }



    public int[] GetUpProgression()
    {
        return upProgression;
    }
}