using Godot;
using Godot.Collections;
using System;

public class WorkTree : Tree
{
    [Export]
    public int COLUMNS_LENGTH = 3;
    [Export]
    private PackedScene allWorksPackedScene;
    [Export]
    private PackedScene workGuiPackedScene;
    [Export]
    private PackedScene skillGuiPackedScene;


    private Array<MyEnum.Work> works;
    private int[] worksLevel;
    private int[,] skillsLevel;
    private AllWorks allWorks;
    private TreeItem[] itens = { };
    private Array<Array<int>> worksUps;

    public override void _Ready()
    {
        allWorks = allWorksPackedScene.Instance<AllWorks>();
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
        Connect("gui_input", this, "_OnGuiInput");
    }


    private void _OnTreeReady()
    {
        TreeItem root = CreateItem();
        itens = new TreeItem[works.Count+skillsLevel.GetLength(0)]; //@?

        int workIndex = 0;
        int itemIndex = 0;

        foreach(MyEnum.Work workEnum in works)
        {
            Work currentWork = allWorks.GetWork(workEnum);
            Skill[] skillList = currentWork.GetSkillList();

            itens[itemIndex] = CreateItem(root);
            itens[itemIndex].SetIcon(0, currentWork.GetBaseImage());
            itens[itemIndex].SetText(0, currentWork.GetWorkName()+" "+worksLevel[workIndex]);
            itens[itemIndex].SetMetadata(0, currentWork);

            itemIndex++;

            for (int j = 0; j < skillList.Length; j++)
            {
                if (j==0)
                    itens[itemIndex] = CreateItem(itens[itemIndex-1]);

                itens[itemIndex].SetText(j, skillList[j].GetSkillName()+" "+skillsLevel[workIndex,j]);
                itens[itemIndex].SetMetadata(j, skillList[j]);

                if (j == skillList.Length - 1)
                    itemIndex++;
            }

            workIndex++;
        }

        MakeBlankUnselected(new[] { root });
        MakeBlankUnselected(itens);
    }


    private void _OnGuiInput(InputEvent @event)
    {
        if (! (@event is InputEventMouseButton)) return;
        var mouseEvent = (InputEventMouseButton) @event;
        if (mouseEvent.Doubleclick && this.GetSelected()!=null)
        {
            OpenGui();
        }
    }


    private void OpenGui()
    {
        TreeItem currentItem = GetSelected();
        object skillWork = currentItem.GetMetadata(this.GetSelectedColumn());
        if (skillWork is Work)
            OpenWorkGui((Work) skillWork);
        else
            OpenSkillGui((Skill) skillWork);
    }


    private void OpenWorkGui(Work work) 
    {
        int workIndex = GetIndexOfWork(work);
        WorkGUI workGui = workGuiPackedScene.Instance<WorkGUI>();

        workGui.SetLevelValue(worksLevel[workIndex]);
        workGui.SetWork(work);
        workGui.SetWorksUps(worksUps[workIndex]);
        workGui.SetWorkIndex(workIndex);
        workGui.ConnectAllSignals(this);

        GetTree().CurrentScene.AddChild(workGui);
        workGui.PopupIt();
    }

    
    private void OpenSkillGui(Skill skill)
    {
        SkillGUI skillGui = skillGuiPackedScene.Instance<SkillGUI>();

        GetTree().CurrentScene.AddChild(skillGui);
        skillGui.PopupIt();
    }


    private void ActualizeLevelLabels()
    {
        foreach(TreeItem item in itens)
        {
            for(int i = 0; i < COLUMNS_LENGTH; i++)
            {
                object data = item.GetMetadata(i);
                if (data is Work)
                    ActualizeWorkLabel(item, i, (Work) data);

                if (data is Skill)
                    ActualizeSkillLabel(item, i,(Skill) data);
            }
        }
    }

    private void ActualizeWorkLabel(TreeItem item, int i, Work data)
    {
        item.SetText(i, $"{data.GetWorkName()} {worksLevel[GetIndexOfWork(data)]}");
    }

    private void ActualizeSkillLabel(TreeItem item, int i, Skill data)
    {
        item.SetText(i, $"{data.GetSkillName()} "+
            $"{skillsLevel[GetSkillOwner(item, i),GetSkillOrder(item,i,data)]}");
    }



    public void _OnWorkValueChanged(int index, int value)
    {
        SetAnWorkLevel(index, value);
    }


    private void MakeBlankUnselected(TreeItem[] itens)
    {
        foreach(TreeItem item in itens)
        {
            for(int i=0; i < COLUMNS_LENGTH; i++)
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
        return works.IndexOf(w.GetEnumWork());
    }

    private int GetSkillOwner(TreeItem item, int i)
    {
        Work owner = (Work) item.GetParent().GetMetadata(i);
        return GetIndexOfWork(owner);
    }

    private int GetSkillOrder(TreeItem item, int id, Skill skill)
    {
        Work owner = (Work)item.GetParent().GetMetadata(id);
        Skill[] skillList = owner.GetSkillList();

        for (int i=0 ; i<skillList.Length ; i++)
        {
            if(skillList[i].GetSkillName() == skill.GetSkillName())
            {
                return i;
            }
        }

        return -1;
    }




    public void SetWorks(Array<MyEnum.Work> _works)
    {
        works = _works;
    }

    public Array<MyEnum.Work> GetWorks()
    {
        return works;
    }


    public void SetWorksLevel(int[] level)
    {
        worksLevel = level;
        ActualizeLevelLabels();
    }

    public void SetAnWorkLevel(int index, int level)
    {
        worksLevel[index] = level;
        ActualizeLevelLabels();
    }

    public int[] GetWorksLevel()
    {
        return worksLevel;
    }

    
    public void SetSkillLevel(int[,] level)
    {
        skillsLevel = level;
    }

    public int[,] GetSkillLevel()
    {
        return skillsLevel;
    }


    public Array<Array<int>> GetWorksUps()
    {
        return worksUps;
    }

    public void SetWorksUps(Array<Array<int>> value)
    {
        worksUps = value;
    }
}
