using Godot;
using System;

public class MyLabel : Label
{
    [Export]
    private String textBase;
    private String textData;


    public new void SetText(String strData)
    {
        textData = strData;
        Text = textBase + textData;
    }

    public String GetTextData()
    {
        return textData;
    }
}
