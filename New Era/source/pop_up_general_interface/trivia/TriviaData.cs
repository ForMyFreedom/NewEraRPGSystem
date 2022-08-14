using Godot;
using System;

public class TriviaData : Node
{
    private string trivia;

    public string GetText()
    {
        return trivia;
    }

    public void SetText(String text)
    {
        trivia = text;
    }
}
