using Godot;
using System;

public class TriviaButton : GeneralButton
{
    String text = "";

    public override void PassDataToPopup()
    {
        TriviaPopup triviaPoup = (TriviaPopup)myPopup;
        triviaPoup.SetTrivia(text);
    }

    public override object GetData()
    {
        return text;
    }

    public override void SetData(object[] data)
    {
        text = (String) data[0];
    }
}
