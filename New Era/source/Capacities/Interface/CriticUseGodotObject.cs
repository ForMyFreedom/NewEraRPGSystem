using Godot;
using System;
using System.Text.RegularExpressions;
using Statics.Enums;

using Entities;
using Entities.Interface;

namespace Capacities.Interface
{
    public abstract class CriticUseGodotObject : Godot.Object, CriticUseInterface
    {
        public abstract void DoEndMechanic(object obj);

        public abstract void DoEndMechanicLogic();

        public abstract void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1);

        public abstract void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);

        public abstract int GetCost();

        public abstract MyEnum.Work GetRelatedWork();

        public abstract string GetText();

        public abstract string GetUseName();

        public abstract void InjectWork(WorkInterface w);

        public abstract bool NotificationAlreadyExist(MainInterface main);
    }
}