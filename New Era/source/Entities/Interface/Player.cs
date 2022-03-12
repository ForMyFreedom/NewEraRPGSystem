using Godot;
using Godot.Collections;
using System;

namespace Entities.Interface
{
    public interface Player : CharacterDataBank
    {
        String GetFileName();
        String GetCurrentSavePath();

        void DoReady();
    }
}