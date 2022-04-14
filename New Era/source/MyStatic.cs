using Godot;
using System;
using System.Text.RegularExpressions;

public static class MyStatic
{
    public static string savePath = "res://saves//"; //"res://saves//"; //OS.GetUserDataDir() + "\\saves\\";

    public static int MaximumUseSurgeCoeficient = 5;

    public static void CenterTheWindow()
    {
        Vector2 screenSize = OS.GetScreenSize(0);
        screenSize.y *= 0.90f;
        Vector2 windowSize = OS.WindowSize;
        OS.WindowPosition = (screenSize - windowSize) * 0.5f;
    }

    public static string GetNotificationText(string baseMessage, int critic, object[] list)
    {
        string finalText = (critic > 0 ? $"[{critic} Criticos] " : "") + baseMessage;
        var regex = new Regex(Regex.Escape("$"));

        if (list != null)
        {
            for (int i = 0; i < list.Length; i++)
            {
                finalText = regex.Replace(finalText, list[i].ToString(), 1);
            }
        }

        return finalText;
    }
}