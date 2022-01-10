using Godot;
using Godot.Collections;
using System;

public class AllWorks : Node
{
    [Export]
    private Dictionary<int, PackedScene> worksDictionary = new Dictionary<int, PackedScene>();


    /**
    private static Dictionary<MyEnum.Work, Work> worksDictionary = new Dictionary<MyEnum.Work, Work>()
    {
        {MyEnum.Work.Artist, }, {MyEnum.Work.Assasin, }, {MyEnum.Work.Cooker, },
        {MyEnum.Work.Engineer, }, {MyEnum.Work.Fighter, }, {MyEnum.Work.Marcialist, },
        {MyEnum.Work.Medic, }, {MyEnum.Work.Navigator, }, {MyEnum.Work.Orator, },
        {MyEnum.Work.Scholar, }, {MyEnum.Work.Shooter, }, {MyEnum.Work.Swordmaster, },

    };
    **/
    

    public Work GetWork(MyEnum.Work workValue)
    {
        return worksDictionary[(int) workValue].Instance<Work>();
    }
}