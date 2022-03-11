using Godot;
using Godot.Collections;
using System;

using Entities;

namespace Capacities.Interface
{
    public interface SkillInterface
    {
        Array<string> GetTextOfMechanicButtons();
        void PlayWayOfLevelCalcule(WorkTree workTree, int workIndex, int skillIndex, int level);

        int GetLevel();
        void SetLevel(int l);
        void AddLevel(int add);

        String GetSkillName();
        String GetSkillDescription();
        void SetSkillDescription(String description);

        Texture GetEffectImage();

        String GetMechanicDescription();
        void SetMechanicDescription(String description);
    }
}