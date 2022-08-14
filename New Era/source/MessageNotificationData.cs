using System;
using Godot;

public class MessageNotificationData
{
    private string message;
    private Texture texture;
    private object[] data;
    private int renewCritic;

    public MessageNotificationData() { }

    public MessageNotificationData(String message, object[] data, Texture texture=null, int renewCritic=-1)
    {
        this.message = message;
        this.data = data;
        this.texture = texture;

        this.renewCritic = renewCritic;
    }

    public bool CriticWasRenewed()
    {
        return renewCritic>-1;
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

    public int GetRenewCritic()
    {
        return renewCritic;
    }
}
