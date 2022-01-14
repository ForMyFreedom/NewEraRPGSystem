using Godot;
using Godot.Collections;
using System;

public class WorkTree : Tree
{
    [Export]
    public int COLUMNS_LENGTH = 3;
    [Export]
    private PackedScene allWorksPackedScene;

    private Array<MyEnum.Work> works;
    private int[] worksLevel;
    private int[,] skillsLevel;
    private AllWorks allWorks;

    public override void _Ready()
    {
        allWorks = allWorksPackedScene.Instance<AllWorks>();
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
        Connect("gui_input", this, "_OnGuiInput");
    }

    private void _OnTreeReady()
    {
        TreeItem root = CreateItem();
        TreeItem[] itens = new TreeItem[works.Count+skillsLevel.GetLength(0)]; //@?

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
        GD.Print("trabajo");
    }

    
    private void OpenSkillGui(Skill skill)
    {
        GD.Print("tecnika");
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
}
