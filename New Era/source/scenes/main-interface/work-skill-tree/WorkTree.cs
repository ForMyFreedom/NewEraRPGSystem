using Godot;
using Godot.Collections;
using System;

using Capacities.Interface;
using Entities;
using Statics.Enums;

public class WorkTree : Tree
{
    [Export]
    private PackedScene workGuiPackedScene;
    [Export]
    private PackedScene skillGuiPackedScene;
    [Export]
    private PackedScene criticGuiPackedScene;
    [Export]
    private Texture useOfCriticTexture;

    private Array<WorkInterface> works;
    private Array<Array<CriticUseInterface>> criticUses;
    private TreeItem[] itens = { };

    public override void _Ready()
    {
        Connect("gui_input", this, "_OnGuiInput");
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
    }


    private void _OnTreeReady()
    {
        TreeItem root = CreateItem();
        itens = new TreeItem[GetTreeItensLength()];
        int workIndex = 0; int itemIndex = 0;

        foreach(WorkInterface currentWork in works)
        {
            AddNewWorkItem(root, itemIndex, currentWork);
            AddUseOfCriticSection(root, itemIndex, workIndex, currentWork);
            itemIndex++;


            if (AddAllSkillItens(itemIndex, workIndex, currentWork))
                itemIndex++;
            workIndex++;
        }

        MakeBlankUnselected(itens);
        InjectWorkInAllCriticUse();
    }


    private void AddNewWorkItem(TreeItem root, int itemIndex, WorkInterface currentWork)
    {
        itens[itemIndex] = CreateItem(root);
        itens[itemIndex].SetIcon(0, currentWork.GetBaseImage());
        itens[itemIndex].SetText(0, currentWork.GetWorkName() + " " + currentWork.GetLevel());
        itens[itemIndex].SetMetadata(0, currentWork);
    }

    private void AddUseOfCriticSection(TreeItem root, int itemIndex, int workIndex, WorkInterface currentWork)
    {
        Array<CriticUseInterface> uses = TryGetWorkCriticUse(workIndex);
        Godot.Collections.Array data = new Godot.Collections.Array(works[workIndex], uses);

        itens[itemIndex].SetIcon(2, useOfCriticTexture);
        itens[itemIndex].SetText(2, "Usos de Critico");
        itens[itemIndex].SetMetadata(2, data);
    }


    private bool AddAllSkillItens(int itemIndex, int workIndex, WorkInterface currentWork)
    {
        SkillInterface[] skillList = currentWork.GetSkillList();
        bool haveAddSkill = false;

        for (int j = 0; j < skillList.Length; j++)
        {
            if (j == 0)
            {
                itens[itemIndex] = CreateItem(itens[itemIndex - 1]);
                haveAddSkill = true;
            }

            itens[itemIndex].SetText(j, skillList[j].GetSkillName() + " " + skillList[j].GetLevel());
            itens[itemIndex].SetMetadata(j, skillList[j]);
        }

        if (haveAddSkill) return true;
        else return false;
    }



    public int RequestSkillRoll(String skillName, int modValue)
    {
        int rollValue = 0; int sumValue = 0;

        foreach(WorkInterface work in works)
        {
            foreach(SkillInterface skill in work.GetSkillList())
            {
                if(skill.GetSkillName() == skillName)
                {
                    rollValue = skill.GetLevel();
                    sumValue = GetAtributeLevel(work.GetRelationedAtribute());
                }
            }
        }

        return RollCode.GetRandomAdvancedRoll(rollValue,sumValue,modValue);
    }


    public int RequestWorkRoll(MyEnum.Work we, int modValue)
    {
        int rollValue = 0; int sumValue = 0;

        foreach (WorkInterface work in works)
        {
            if (work.GetEnumWork() == we)
            {
                rollValue = work.GetLevel();
                sumValue = GetAtributeLevel(work.GetRelationedAtribute());
            }
        }

        return RollCode.GetRandomAdvancedRoll(rollValue, sumValue, modValue);
    }






    private void _OnGuiInput(InputEvent @event)
    {
        if (! (@event is InputEventMouseButton)) return;
        var mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick && this.GetSelected()!=null)
            OpenGui();
    }


    private void OpenGui()
    {
        TreeItem currentItem = GetSelected();
        object itemData = currentItem.GetMetadata(this.GetSelectedColumn());
        if (itemData is WorkInterface)
        {
            OpenWorkGui((WorkInterface)itemData);
        }
        else if (itemData is SkillInterface)
        {
            OpenSkillGui((SkillInterface)itemData);
        }
        else if (itemData is Godot.Collections.Array)
        {
            OpenUsesOfCriticGui((Godot.Collections.Array) itemData);
        }
    }


    private void OpenWorkGui(WorkInterface work) 
    {
        int workIndex = GetIndexOfWork(work);
        WorkGUI workGui = workGuiPackedScene.Instance<WorkGUI>();

        //@@@@@@@@@
        workGui.SetWork(work);
        workGui.SetWorkIndex(workIndex);
        workGui.ConnectAllSignals(this);
        //@@@@@@@@@

        GetTree().CurrentScene.AddChild(workGui);
        workGui.PopupIt();
    }

    
    private void OpenSkillGui(SkillInterface skill)
    {
        SkillGUI skillGui = skillGuiPackedScene.Instance<SkillGUI>();

        //@@@@@@@@@
        int[] skillIndex = GetIndexOfSkill(skill);
        skillGui.SetSkill(skill);
        skillGui.SetWork(works[skillIndex[0]]);
        skillGui.SetSkillIndex(skillIndex[1]);
        skillGui.SetWorkIndex(skillIndex[0]);
        skillGui.ConnectAllSignals(this);
        //@@@@@@@@@

        GetTree().CurrentScene.AddChild(skillGui);
        skillGui.PopupIt();
    }

    private void OpenUsesOfCriticGui(Godot.Collections.Array uses)
    {
        CriticGUI criticGui = criticGuiPackedScene.Instance<CriticGUI>();
        criticGui.SetWork((WorkInterface)uses[0]);
        criticGui.SetCriticUses((Godot.Collections.Array) uses[1]);

        GetTree().CurrentScene.AddChild(criticGui);
        criticGui.PopupIt();
    }


    private void ActualizeLevelLabels()
    {
        foreach(TreeItem item in itens)
        {
            for(int i = 0; i < Columns; i++)
            {
                object data = item.GetMetadata(i);
                if (data is WorkInterface)
                    ActualizeWorkLabel(item, i, (WorkInterface) data);

                if (data is SkillInterface)
                    ActualizeSkillLabel(item, i,(SkillInterface) data);
            }
        }
    }

    //@
    private void ActualizeWorkLabel(TreeItem item, int i, WorkInterface data)
    {
        item.SetText(i, $"{data.GetWorkName()} {data.GetLevel()}");
    }

    //@
    private void ActualizeSkillLabel(TreeItem item, int i, SkillInterface data)
    {
        int[] index = GetIndexOfSkill(data); //@
        item.SetText(i, $"{data.GetSkillName()} {data.GetLevel()}");
    }



    public void _OnWorkValueChanged(int index, int value)
    {
        SetAnWorkLevel(index, value);
    }

    public void _OnSkillValueChanged(int workIndex, int skillIndex, int value)
    {
        SetAnSkillLevel(workIndex, skillIndex, value);
    }


    private void MakeBlankUnselected(TreeItem[] itens)
    {
        foreach(TreeItem item in itens)
        {
            for(int i=0; i < Columns; i++)
            {
                if (item.GetText(i) == "")
                {
                    item.SetSelectable(i, false);
                }
            }
        }
    }

    private Array<CriticUseInterface> TryGetWorkCriticUse(int index)
    {
        try
        {
            return criticUses[index];
        }
        catch (Exception)
        {
            return new Array<CriticUseInterface>();
        }
    }


    private int GetIndexOfWork(WorkInterface w)
    {
        return works.IndexOf(w);
    }

    private int[] GetIndexOfSkill(SkillInterface s)
    {
        for (int i = 0; i < works.Count; i++)
        {
            WorkInterface actualWork = works[i];
            SkillInterface[] actualSkillList = actualWork.GetSkillList();
            for (int j = 0; j < actualSkillList.Length; j++)
            {
                if (actualSkillList[j].GetSkillName() == s.GetSkillName())
                {
                    return new int[] { i, j };
                }
            }
        }

        return null;
    }


    //@
    private void VerifySkillLeveling(int workIndex, int level)
    {
        SkillInterface[] worksSkillList = works[workIndex].GetSkillList();
        for(int i=0; i < worksSkillList.Length; i++)
        {
            worksSkillList[i].PlayWayOfLevelCalcule(this, workIndex, i, level);
        }
    }


    private void InjectWorkInAllCriticUse()
    {
        for(int i = 0; i < criticUses.Count; i++)
        {
            WorkInterface currentWork = works[i];
            foreach(CriticUseInterface use in criticUses[i])
                use.InjectWork(currentWork);
        }
    }



    public void SetWorks(Array<WorkInterface> w)
    {
        works = w;
    }

    public Array<WorkInterface> GetWorks()
    {
        return works;
    }
    
    public void SetWorksLevel(int[] level)
    {
        for(int i=0; i < works.Count; i++)
            SetAnWorkLevel(i, level[i]);
    }

    public void SetAnWorkLevel(int index, int level)
    {
        works[index].SetLevel(level);
        VerifySkillLeveling(index, level);
        ActualizeLevelLabels();
    }


    public void SetSkillLevel(int[,] level)
    {
        for (int i = 0; i < works.Count; i++)
        {
            for(int j = 0; j < works[i].GetSkillList().Length; j++)
            {
                SetAnSkillLevel(i, j, level[i,j]);
            }
        }
    }

    public void SetAnSkillLevel(int workIndex, int skillIndex, int level)
    {
        WorkInterface work = works[workIndex];
        SkillInterface skill = work.GetSkillList()[skillIndex];
        skill.SetLevel(level);
        ActualizeLevelLabels();
    }


    public Array<Array<int>> GetWorksUps()
    {
        Array<Array<int>> worksUps = new Array<Array<int>>();
        foreach(WorkInterface w in works)
        {
            worksUps.Add(w.GetWorksUp());
        }
        return worksUps;
    }

    public void SetWorksUps(Array<Array<int>> value)
    {
        for(int i=0; i < works.Count; i++)
        {
            works[i].SetWorksUp(value[i]);
        }
    }


    private int GetTreeItensLength()
    {
        int c=0;
        foreach(WorkInterface w in works)
        {
            c++;
            if (w.GetSkillList().Length > 0) c++;
        }
        return c;
    }


    private int GetAtributeLevel(MyEnum.Atribute atributeEnum)
    {
        MainInterface main = (MainInterface)GetTree().CurrentScene;
        Atributo atribute = main.GetAtributeNodeByEnum(atributeEnum);
        return atribute.GetAtributeValue();
    }

    public Array<Array<CriticUseInterface>> GetCriticUses()
    {
        return criticUses;
    }

    public void SetCriticUses(Array<Array<CriticUseInterface>> uses)
    {
        criticUses = uses;
    }
}
