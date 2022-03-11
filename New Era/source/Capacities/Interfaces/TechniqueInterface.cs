using Godot;
using System;

using Statics.Enums;
using Entities;

namespace Capacities.Interface
{
    public interface TechniqueInterface
    {
        void ExecuteAllCritics(MainInterface main);

        void DoAttackRollNotification(MainInterface main);
        void InjectWorks(WorkInterface[] ws);

        String GetTechniqueName();

        MyEnum.Work[] GetRelatedWorks();
        Work[] GetInjectedWorks();
        CriticUse[] GetCriticUses();

        int[] GetPowerOfCritics();
        int[] GetActionIndexOfCritics();
        int GetLevel();
    }
}