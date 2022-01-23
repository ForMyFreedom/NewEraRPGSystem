using Godot;
using Godot.Collections;
using System;

public class Notification : ItemList
{
    private String text;
    private Texture image;

    public Notification(object ob1, object ob2)
    {
        text = (String) ob1;
        image = (Texture) ob2;
    }



    public String GetText()
    {
        return text;
    }

    public void SetText(String t)
    {
        text = t;
    }

    public Texture GetImage()
    {
        return image;
    }

    public void SetImage(Texture texture)
    {
        image = texture;
    }
}