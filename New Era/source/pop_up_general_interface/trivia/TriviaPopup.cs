using Godot;
using System;

public class TriviaPopup : MyPopup
{
    [Export]
    protected NodePath labelPath;

    private TriviaData triviaData;

    public override void InjectDataNode(Node baseData)
    {
        triviaData = (TriviaData) baseData;
    }

    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
        GetNode<TextEdit>(labelPath).Text = triviaData.GetTrivia();
        GetNode(labelPath).Connect("text_changed", this, "_OnTextChanged");
    }


    public void _OnTextChanged()
    {
        triviaData.SetTrivia(GetNode<TextEdit>(labelPath).Text);
    }

}
