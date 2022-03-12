using Godot;
using Godot.Collections;
using System;

using Statics.Enums;
using Capacities.Interface;

namespace Entities.Interface
{
    public interface MainInterface : CharacterDataBank
    {
        void ConnectToLastNotification(Godot.Object obj, String funcName);
        void CreateNewNotification(String message, Texture texture = null);
        Atributo GetAtributeNodeByEnum(MyEnum.Atribute atribute); //@
        int GetSelectedWeaponDamage();
        SkillInterface GetSkillByWorkAndIndex(MyEnum.Work workEnum, int index);
        SkillInterface GetSkillByWorkAndName(MyEnum.Work workEnum, String name);
        WorkInterface GetWorkNodeByEnum(MyEnum.Work workEnum);

        int RequestWorkRoll(MyEnum.Work we, int modValue = 0);
        int RequestAtributeRoll(MyEnum.Atribute ae, int modValue = 0);
        int RequestSkillRoll(String skillName, int modValue = 0);
        void RequestSkillMechanic(MyEnum.Work work, int skillIndex, int modValue = 0, int actionIndex = 0);


        void AddStrength(int mod);
        void AddAgility(int mod);
        void AddMind(int mod);
        void AddSenses(int mod);
        void AddCharisma(int mod);

        void AddModStrength(int mod);
        void AddModAgility(int mod);
        void AddModMind(int mod);
        void AddModSenses(int mod);
        void AddModCharisma(int mod);

        void AddActualLife(int mod);
        void AddActualSurge(int mod);
        void AddActualAgiDefense(int mod);
        void AddActualStrDefense(int mod);

        void AddModAgiDefense(int mod);
        void AddModStrDefense(int mod);
        void AddModLife(int mod);
        void AddModSurge(int mod);

        void AddAnSkillLevel(MyEnum.Work enumWork, int skillIndex, int levelAdd);
        void AddAnAtributeLevel(MyEnum.Atribute enumAtribute, int levelAdd);
        void AddExtraDamage(int value);
        void AddGuard(int value);
        void UpdateInventory(); //@
    }
}