using Godot;
using System;

public class CustomRollPopup : MyPopup
{
    [Export]
    private NodePath rollLineList;
    [Export]
    private NodePath baseColorPath;

    private CustomRollData rollData;

    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
    }

    public override void InjectDataNode(Node baseData) {
        rollData = (CustomRollData) baseData;

        foreach (CustomRollLine rollLine in GetNode<Node>(rollLineList).GetChildren())
        {
            rollLine.SetPrincipalColor(rollData.GetPrincipalColor());
            rollLine.SetSecondaryColor(rollData.GetSecondaryColor());
        }

        Color baseColor = rollData.GetSecondaryColor();
        baseColor.a8 = 50;
        GetNode<ColorRect>(baseColorPath).Color = baseColor;
    }

}
