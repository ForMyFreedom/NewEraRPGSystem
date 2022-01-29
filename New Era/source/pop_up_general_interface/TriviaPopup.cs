using Godot;
using System;

public class TriviaPopup : MyPopup
{
    [Export]
    protected NodePath labelPath;

    private String trivia;


    public override void PopupIt()
    {
        PopupCenteredRatio(RATIO);
    }

    public override void PassDataToMain()
    {
        main.SetTrivia(GetTrivia());
    }



    public String GetTrivia()
    {
        return GetNode<TextEdit>(labelPath).Text;
    }
    
    public void SetTrivia(String text)
    {
        trivia = text;
        GetNode<TextEdit>(labelPath).Text = trivia;
    }

}
