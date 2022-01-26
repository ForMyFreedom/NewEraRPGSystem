using Godot;
using Godot.Collections;
using System;

public class WorkTree : Tree
{
    [Export]
    private PackedScene workGuiPackedScene;
    [Export]
    private PackedScene skillGuiPackedScene;


    private Array<Work> works;
    
    private TreeItem[] itens = { };

    public override void _Ready()
    {
        Connect("gui_input", this, "_OnGuiInput");
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
    }


    private void _OnTreeReady()
    {
        TreeItem root = CreateItem();
        itens = new TreeItem[2*works.Count];
        int workIndex = 0; int itemIndex = 0;

        foreach(Work currentWork in works)
        {
            AddNewWorkItem(root, itemIndex, workIndex, currentWork);
            itemIndex++;

            AddAllSkillItens(itemIndex, workIndex, currentWork);
            workIndex++;
        }

        MakeBlankUnselected(itens);
    }


    private void AddNewWorkItem(TreeItem root, int itemIndex, int workIndex, Work currentWork)
    {
        itens[itemIndex] = CreateItem(root);
        itens[itemIndex].SetIcon(0, currentWork.GetBaseImage());
        itens[itemIndex].SetText(0, currentWork.GetWorkName() + " " + currentWork.GetLevel());
        itens[itemIndex].SetMetadata(0, currentWork);
    }

    private void AddAllSkillItens(int itemIndex, int workIndex, Work currentWork)
    {
        Skill[] skillList = currentWork.GetSkillList();

        for (int j = 0; j < skillList.Length; j++)
        {
            if (j == 0)
                itens[itemIndex] = CreateItem(itens[itemIndex - 1]);

            itens[itemIndex].SetText(j, skillList[j].GetSkillName() + " " + skillList[j].GetLevel());
            itens[itemIndex].SetMetadata(j, skillList[j]);

            if (j == skillList.Length - 1)
                itemIndex++;
        }

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
        if (itemData is Work)
            OpenWorkGui((Work) itemData);
        else
            OpenSkillGui((Skill) itemData);
    }


    private void OpenWorkGui(Work work) 
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

    
    private void OpenSkillGui(Skill skill)
    {
        SkillGUI skillGui = skillGuiPackedScene.Instance<SkillGUI>();

        //@@@@@@@@@
        int[] skillIndex = GetIndexOfSkill(skill);
        skillGui.SetSkill(skill);
        skillGui.SetSkillLevel(works[skillIndex[0]].GetSkillList()[skillIndex[1]].GetLevel());
        skillGui.SetWork(works[skillIndex[0]]);
        skillGui.SetSkillIndex(skillIndex[1]);
        skillGui.SetWorkIndex(skillIndex[0]);
        skillGui.ConnectAllSignals(this);
        //@@@@@@@@@

        GetTree().CurrentScene.AddChild(skillGui);
        skillGui.PopupIt();
    }


    private void ActualizeLevelLabels()
    {
        foreach(TreeItem item in itens)
        {
            for(int i = 0; i < Columns; i++)
            {
                object data = item.GetMetadata(i);
                if (data is Work)
                    ActualizeWorkLabel(item, i, (Work) data);

                if (data is Skill)
                    ActualizeSkillLabel(item, i,(Skill) data);
            }
        }
    }

    //@
    private void ActualizeWorkLabel(TreeItem item, int i, Work data)
    {
        item.SetText(i, $"{data.GetWorkName()} {data.GetLevel()}");
    }

    //@
    private void ActualizeSkillLabel(TreeItem item, int i, Skill data)
    {
        int[] index = GetIndexOfSkill(data);
        item.SetText(i, $"{data.GetSkillName()} {works[index[0]].GetSkillList()[index[1]]}");
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
            GD.Print(item.GetText(0));
            for(int i=0; i < Columns; i++)
            {
                if (item.GetText(i) == "")
                {
                    item.SetSelectable(i, false);
                }
            }
        }
    }




    private int GetIndexOfWork(Work w)
    {
        return works.IndexOf(w);
    }

    private int[] GetIndexOfSkill(Skill s)
    {
        for (int i = 0; i < works.Count; i++)
        {
            Work actualWork = works[i];
            Skill[] actualSkillList = actualWork.GetSkillList();
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
        Skill[] worksSkillList = works[workIndex].GetSkillList();

        for(int i=0; i < worksSkillList.Length; i++)
        {
            worksSkillList[i].PlayWayOfLevelCalcule(this, workIndex, i, level);
        }

    }



    public void SetWorks(Array<Work> w)
    {
        works = w;
    }

    public Array<Work> GetWorks()
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
        Work work = works[workIndex];
        Skill skill = work.GetSkillList()[skillIndex];
        skill.SetLevel(level);
        ActualizeLevelLabels();
    }


    public Array<Array<int>> GetWorksUps()
    {
        Array<Array<int>> worksUps = new Array<Array<int>>();
        foreach(Work w in works)
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
}
