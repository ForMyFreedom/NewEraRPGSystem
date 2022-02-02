using Godot;
using Godot.Collections;
using System.Linq;
using System;

public class CriticGUI : WindowDialog
{
    [Export]
    private NodePath criticTreePath;

    private Work work;
    private Array<CriticUse> criticUses;


    public void PopupIt()
    {
        PopupCenteredRatio(0.5f);
    }

    public override void _Ready()
    {
        WindowTitle += work.GetWorkName();
        InitializeTree();
    }

    private void InitializeTree()
    {
        Tree criticTree = GetNode<Tree>(criticTreePath);
        TreeItem root = criticTree.CreateItem();
        
        foreach(CriticUse use in criticUses)
        {
            TreeItem item = GetNode<Tree>(criticTreePath).CreateItem(root);
            item.SetText(0, GetFormatedText(use));
        }
    }

    private String GetFormatedText(CriticUse use)
    {
        return $"{use.GetUseName()} [{GetCriticCost(use)}]: \n {use.GetText()}";
    }


    private String GetCriticCost(CriticUse use)
    {
        if (use.GetCost() < 0)
            return "N";
        else
            return use.GetCost().ToString();
    }


    public void SetWork(Work w)
    {
        work = w;
    }

    public Array<CriticUse> GetCriticUses()
    {
        return criticUses;
    }

    public void SetCriticUses(Godot.Collections.Array uses)
    {
        criticUses = new Array<CriticUse>();
        foreach(CriticUse use in uses)
        {
            criticUses.Add(use);
        }
    }
}