using Godot;
using System;

public class CustomRollPopup : MyPopup
{
    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
    }

    public override void InjectDataNode(Node baseData)
    {
    }
}
