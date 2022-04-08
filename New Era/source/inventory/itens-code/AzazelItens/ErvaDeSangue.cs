using Godot;
using Godot.Collections;
using System;

public class ErvaDeSangue : ItemCode
{
    [Export]
    private Texture image;
    [Export]
    private Resource violenceTechnique;

    private int bonusStr;
    private int bonusAgi;
    private Array<Technique> noViolenceTechniques;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        item.RemoveQuantity();
        main.UpdateInventory();

        int charismaImpact = -2*main.GetCharisma();

        bonusStr = (int)(main.GetStrength()/2.5);
        bonusAgi = (int)(main.GetAgility()/2.5);

        main.AddModStrength(bonusStr);
        main.AddModAgility(bonusAgi);

        RemoveAllNoViolenceTechniques(main);
        main.AddTechnique((Technique) violenceTechnique);

        return new MessageNotificationData(
            message, new object[] { charismaImpact }, image
        );
    }


    public override void DoEndMechanicLogic()
    {
        main.AddModStrength(-bonusStr);
        main.AddModAgility(-bonusAgi);

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

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
