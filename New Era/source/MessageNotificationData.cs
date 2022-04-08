using System;
using Godot;

public class MessageNotificationData
{
    private string message;
    private Texture texture;
    private object[] data;

    public MessageNotificationData() { }

    public MessageNotificationData(String message, object[] data, Texture texture=null)
    {
        this.message = message;
        this.data = data;
        this.texture = texture;
    }

    public String GetMessage()
    {
        return message;
    }

    public object[] GetData()
    {
        return data;
    }

    public Texture GetTexture()
    {
        return texture;
    }
}
