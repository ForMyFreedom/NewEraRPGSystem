using Godot;
using System;

public class Assasin : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddAgility(1);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreatePowerMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui) //@
    {
        gui.CreateNewNotification("Voce alcansou uma maestria de Assasino! Escolha entre: \n"+
            "- Assasino Regular +I: +4 Letalidade \n"+
            "- Assasino Ninja + I: +8 Letalidade ao atacar furtivamente \n"+
            "- Assasino Chacina + I: +8 Letalidade ao atacar em um combate \n", 
       baseImage);
    }
}
