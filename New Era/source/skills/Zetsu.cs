using Godot;
using Godot.Collections;
using System;

public class Zetsu : Skill
{
    int agiDefense;
    int strDefense;
    int guard;

    public override Array<string> GetTextOfMechanicButtons()
    {
        return new Array<string>() { "Zetsu" };
    }

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = 0;

        this.main = main;

        agiDefense = main.GetActualAgiDefense();
        strDefense = main.GetActualStrDefense();
        guard = main.GetGuard();

        ModifyDefenseFactors(0.5f);

        main.CreateNewNotification("Forma de Haki Zetsu: Voce recebe: "+
            $"+{3*level} em Testes Sigilosos \n"+
            $"+{level} em Recuperacao de Surto de Acao a cada final de turno \n"+
             "Mas sua Guarda e Defesas sao reduzidas pela metade, e voce nao pode usar Hatsus", effectImage
        );

        ConnectToLastNotification(main);

        //@turn win of surge
    }

    
    public override void DoEndMechanicLogic()
    {
        ModifyDefenseFactors(1);
    }


    private void ModifyDefenseFactors(float mod)
    {
        main.SetActualAgiDefense((int)(agiDefense*mod));
        main.SetActualStrDefense((int)(strDefense *mod));
        main.SetGuard((int)(guard *mod));
    }
}