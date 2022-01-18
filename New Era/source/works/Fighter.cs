using Godot;
using System;

public class Fighter : Work
{
    public override void DoFirstUpStep(MainInterface gui) //@
    {
        GD.Print("first");
    }

    public override void DoSecondUpStep(MainInterface gui) //@
    {
        GD.Print("second");
    }

    public override void DoThirdUpStep(MainInterface gui) //@
    {
        GD.Print("thrid");
    }
}
