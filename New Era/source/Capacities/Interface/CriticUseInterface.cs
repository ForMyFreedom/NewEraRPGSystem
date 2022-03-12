using Godot;
using System;
using System.Text.RegularExpressions;
using Statics.Enums;

using Entities;

namespace Capacities.Interface
{
    public interface CriticUseInterface : NotificationConsumerInterface
    {
        String GetUseName();
        String GetText();

        MyEnum.Work GetRelatedWork();
        void InjectWork(WorkInterface w);

        int GetCost();
    }
}