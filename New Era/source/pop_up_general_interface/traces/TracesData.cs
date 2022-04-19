using Godot;
using Godot.Collections;
using System;

public class TracesData : Node
{
    private Array<Trace> traces;


    public Array<Trace> GetTraces()
    {
        return traces;
    }

    public void SetTraces(Array<Trace> traces)
    {
        this.traces = traces;
    }
}
