using Godot;
using System;

using Statics.Enums;
using Entities.Interface;

namespace Capacities.Interface
{
    public interface TechniqueInterface : NotificationConsumerInterface
    {
        void ExecuteAllCritics(MainInterface main);

        void DoAttackRollNotification(MainInterface main);
        void InjectWorks(WorkInterface[] ws);

        String GetTechniqueName();

        MyEnum.Work[] GetRelatedWorks();
        WorkInterface[] GetInjectedWorks();
        CriticUseInterface[] GetCriticUses();

        int[] GetPowerOfCritics();
        int[] GetActionIndexOfCritics();
        int GetLevel();
    }
}