using Godot;
using Godot.Collections;
using System;

public class ErvaDeSangue : ItemCode
{
    [Export]
    private Texture image;
    [Export]
    private Resource violenceTechnique;

    private int actualSTR;
    private int actualAGI;
    private Array<Technique> noViolenceTechniques;

    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        item.RemoveQuantity();
        main.UpdateInventory();

        int charismaImpact = -2*main.GetCharisma();
        int damage = (main.GetStrength() + main.GetAgility()) / 2;

        actualSTR = main.GetStrength();
        actualAGI = main.GetAgility();

        main.AddModStrength(actualSTR);
        main.AddModAgility(actualAGI);

        RemoveAllNoViolenceTechniques(main);
        main.AddTechnique((Technique) violenceTechnique);

        main.CreateNewNotification(
            MyStatic.GetNotificationText(message, charismaImpact, damage), image
        );
        ConnectToLastNotification(main);
    }


    public override void DoEndMechanicLogic()
    {
        main.AddModStrength(-actualSTR);
        main.AddModAgility(-actualAGI);

        main.RemoveTechnique((Technique) violenceTechnique);
        AddAllNoViolenceTechniques();
    }



    private void RemoveAllNoViolenceTechniques(MainInterface main)
    {
        noViolenceTechniques = main.GetTechniques().Duplicate();

        foreach (Technique tech in noViolenceTechniques)
        {
            main.RemoveTechnique(tech);
        }
    }


    private void AddAllNoViolenceTechniques()
    {
        foreach (Technique tech in noViolenceTechniques)
        {
            main.AddTechnique(tech);
        }
    }

    public int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
