using Godot;
using System;

public static class MyEnum
{
    public enum Factor { LIFE, SURGE, AGI_DEF, STR_DEF };
    
    public enum Atribute { STR, AGI, SEN, MIN, CHA, VON, UND };
    
    public enum Work {
        Swordmaster, Assasin, Shooter, Fighter, Marcialist, Cooker, 
        Navigator, Scholar, Engineer, Medic, Artist, Orator, AkumaNoMi,
        None, Haki, Gensoku, Harmony, Junglement
    };

    public enum DefenseStyle { StrDefense, AgiDefense };

}