using Godot;
using System;

public class TriviaData : Node
{
    private string trivia;

    public string GetTrivia()
    {
        return trivia;
    }

    public void SetTrivia(String text)
    {
        trivia = text;
    }
}
