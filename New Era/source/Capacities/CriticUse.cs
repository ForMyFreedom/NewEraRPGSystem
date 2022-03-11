using Godot;
using System;
using System.Text.RegularExpressions;
using Statics.Enums;

using Entities;

namespace Capacities
{
    public abstract class CriticUse : NotificationConsumer, Interface.CriticUseInterface
    {
        [Export]
        protected String criticUseName;
        [Export]
        protected MyEnum.Work relatedWork;
        [Export(PropertyHint.MultilineText)]
        protected String text;
        [Export(PropertyHint.MultilineText)]
        protected String baseMessage;
        [Export]
        protected int cost; //-1 -> N

        protected Work injectedWork;

        public override abstract void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
        public override abstract void DoEndMechanicLogic();


        protected string GetNotificationText(params object[] list)
        {
            string finalText = baseMessage;
            var regex = new Regex(Regex.Escape("$"));
            for (int i = 0; i < list.Length; i++)
            {
                finalText = regex.Replace(finalText, list[i].ToString(), 1);
            }
            return finalText;
        }

        public String GetUseName()
        {
            return criticUseName;
        }

        public MyEnum.Work GetRelatedWork()
        {
            return relatedWork;
        }

        public String GetText()
        {
            return text;
        }

        public int GetCost()
        {
            return cost;
        }

        public void InjectWork(Work w)
        {
            injectedWork = w;
        }
    }
}