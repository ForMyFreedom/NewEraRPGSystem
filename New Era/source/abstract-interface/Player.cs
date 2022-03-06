using Godot;
using Godot.Collections;
using System;

public interface Player : CharacterDataBank
{
    String GetFileName();
    String GetCurrentSavePath();

    void DoReady();
}