using Godot;
using System;

public class CustomRollPopup : MyPopup
{
    public override void PassDataToMain()
    {
    }

    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
    }
}
