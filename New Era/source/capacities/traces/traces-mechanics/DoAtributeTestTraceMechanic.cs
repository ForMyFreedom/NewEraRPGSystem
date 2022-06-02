using Godot;
using System;

public class DoAtributeTestTraceMechanic : TraceMechanic
{
    [Export]
    private MyEnum.Atribute atributeEnum;
    [Export]
    private float linearMod;
    [Export]
    private int constMod;
    [Export]
    private int sumMod;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int value = main.GetTotalAtributeValue(atributeEnum);
        value = (int)(value * linearMod + constMod);
        int result = RollCode.GetRandomBasicRoll(value)+value+sumMod;

        return new MessageNotificationData(
            baseMessage, new object[] { result }, trace.GetTraceImage()
        );
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}
