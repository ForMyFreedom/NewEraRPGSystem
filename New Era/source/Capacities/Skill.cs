using Godot;
using Godot.Collections;
using System;

using Entities.Interface;

namespace Capacities
{
    public abstract class Skill : NotificationConsumer, Interface.SkillInterface
    {
        [Export]
        protected string skillName;
        [Export]
        protected Texture effectImage;
        [Export]
        protected CSharpScript wayOfLevelCalculeScript;
        [Export]
        protected String skillDescription;
        [Export(PropertyHint.MultilineText)]
        protected String notificationText;
        [Export(PropertyHint.MultilineText)]
        protected String mechanicDescription;
        [Export]
        protected int level;

        private WayOfCalculeSkill wayOfLevelCalcule;


        public abstract Array<string> GetTextOfMechanicButtons();

        public override abstract void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1);
        public override abstract void DoEndMechanicLogic();


        public String GetSkillName()
        {
            return skillName;
        }

        public void PlayWayOfLevelCalcule(WorkTree workTree, int workIndex, int skillIndex, int level)
        {
            wayOfLevelCalcule = (WayOfCalculeSkill)wayOfLevelCalculeScript.New();
            wayOfLevelCalcule.CalculeLevelSkill(workTree, workIndex, skillIndex, level);
        }


        public int GetLevel()
        {
            return level;
        }

        public void SetLevel(int l)
        {
            level = l;
        }

        public void AddLevel(int add)
        {
            level += add;
        }


        public String GetSkillDescription()
        {
            return skillDescription;
        }

        public void SetSkillDescription(String description)
        {
            skillDescription = description;
        }

        public Texture GetEffectImage()
        {
            return effectImage;
        }

        public String GetMechanicDescription()
        {
            return mechanicDescription;
        }

        public void SetMechanicDescription(String description)
        {
            mechanicDescription = description;
        }
    }
}