using Godot;

public class WorkCriticEntity : CriticEntity
{
    [Export]
    private MyEnum.Work relatedWork;

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
