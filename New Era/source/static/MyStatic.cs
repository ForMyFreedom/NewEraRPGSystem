using Godot;
using System;

public static class MyStatic
{
    public static string savePath = "res://saves//"; //"res://saves//"; //OS.GetUserDataDir() + "\\saves\\";


    public static void CenterTheWindow()
    {
        Vector2 screenSize = OS.GetScreenSize(0);
        screenSize.y *= 0.90f;
        Vector2 windowSize = OS.WindowSize;
        OS.WindowPosition = (screenSize - windowSize) * 0.5f;
    }
}