using Godot;
using Godot.Collections;
using System;

public class TracesPopup : MyPopup
{
    [Export]
    protected NodePath traceTreePath;

    private TracesData tracesNodeData;
    private Array<Trace> traces;

    public override void InjectDataNode(Node baseData)
    {
        tracesNodeData = (TracesData)baseData;
        traces = tracesNodeData.GetTraces();
    }

    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
        DoReady();
    }

    private void DoReady()
    {
        CustomTreeItem tracesTreeItem = GetNode<CustomTreeItem>(traceTreePath);

        foreach(Trace trace in traces)
        {
            Control newItem = tracesTreeItem.CreateNewItem(GetTextData(trace));
            newItem.Connect("trace_activated", this, "_OnTraceActivated");
        }
    }


    private void _OnTraceActivated(int traceIndex)
    {
        traces[traceIndex].DoMechanic(GetMain());
    }

    private Dictionary<string, object> GetTextData(Trace trace)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data["_name"] = trace.GetTraceName();
        data["_text"] = trace.GetText();
        return data;
    }


}
