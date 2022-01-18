using Godot;
using Godot.Collections;
using System;

public class WorkUp
{
    private static int[] upProgression = new[] { 5, 10, 50 };

    public static Array<int> CalculeWorkUps(int value)
    {
        Array<int> newWorkUps = new Array<int>(0, 0, 0);

        for (int i = 0; i < 3; i++)
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


    public static Array<Array<int>> GetBlankWorkUpArray(int len)
    {
        Array<Array<int>> workArray = new Array<Array<int>>();
        for(int i = 0; i < len; i++)
        {
            Array<int> up = new Array<int>();
            for(int j = 0; j < 3; j++)
            {
                up.Add(0);
            }
            workArray.Add(up);
        }
        return workArray;
    }


    public int[] GetUpProgression()
    {
        return upProgression;
    }
}