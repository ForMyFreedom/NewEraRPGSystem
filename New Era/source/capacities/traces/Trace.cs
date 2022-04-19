using Godot;
using System;

public class Trace : Resource
{
    [Export]
    private Texture traceImage;
    [Export]
    private String traceName;
    [Export(PropertyHint.MultilineText)]
    private String text;
    [Export]
    private TraceMechanic traceMechanic;


    public void DoMechanic(MainInterface main)
    {
        if (traceMechanic == null) return;
        traceMechanic.InjectTrace(this);
        traceMechanic.DoMechanic(main);
    }




    public Texture GetTraceImage()
    {
        return traceImage;
    }

    public string GetTraceName()
    {
        return traceName;
    }

    public string GetText()
    {
        return text;
    }

    public TraceMechanic GetTraceMechanic()
    {
        return traceMechanic;
    }
}
