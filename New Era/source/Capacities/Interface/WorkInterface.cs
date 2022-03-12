using Godot;
using Godot.Collections;
using System;

using Statics.Enums;
using Entities.Interface;

namespace Capacities.Interface
{
    public interface WorkInterface
    {
        void DoFirstUpStep(MainInterface gui);
        void DoSecondUpStep(MainInterface gui);
        void DoThirdUpStep(MainInterface gui);
        void DoForthUpStep(MainInterface gui);

        int GetBaseDamage(MainInterface gui, int weaponDamage = 0, int actionIndex = 0);

        String GetWorkName();
        Texture GetBaseImage();

        string GetDescription();
        string GetPathDescription();
        string GetMaestryDescription();
        
        MyEnum.Work GetEnumWork();
        Skill[] GetSkillList();
        MyEnum.Atribute GetRelationedAtribute();

        int GetLevel();
        void SetLevel(int l);
        
        Array<int> GetWorksUp();
        void SetWorksUp(Array<int> wu);
    }
}