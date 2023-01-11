using Godot;
using Godot.Collections;
using System;

public class Focus : Skill
{
    [Export(PropertyHint.MultilineText)]
    private string criticPrecisionText;

    [Export(PropertyHint.MultilineText)]
    private string certainPrecisionText;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        switch (actionIndex)
        {
            case 0:
                return new MessageNotificationData(
                    criticPrecisionText, new object[] { }, effectImage
                );
            case 1:
                return new MessageNotificationData(
                    certainPrecisionText, new object[] { level }, effectImage
                );
        }

        return null;
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}