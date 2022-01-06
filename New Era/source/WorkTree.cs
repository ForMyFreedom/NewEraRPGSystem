using Godot;
using System;

public class WorkTree : Tree
{
    [Export]
    public int COLUMNS_LENGTH = 3;

    [Export]
    private Texture test1Texture;
    [Export]
    private Texture test2Texture;
    [Export]
    private Texture arrowTexture;

    public override void _Ready()
    {
        TreeItem root = CreateItem();
        TreeItem[] itens = new TreeItem[4];

        itens[0] = CreateItem(root);
        itens[0].SetIcon(0,test1Texture);
        itens[0].SetText(0, "Medicina");

        itens[1] = CreateItem(itens[0]);
        itens[1].SetIcon(0, arrowTexture);
        itens[1].SetIcon(1, arrowTexture);

        itens[2] = CreateItem(root);
        itens[2].SetIcon(0, test2Texture);
        itens[2].SetText(0, "Assasinato");

        itens[3] = CreateItem(itens[2]);
        itens[3].SetIcon(0, arrowTexture);

        MakeBlankUnselected(new[] { root });
        MakeBlankUnselected(itens);
    }


    private void MakeBlankUnselected(TreeItem[] itens)
    {
        foreach(TreeItem item in itens)
        {
            for(int i=0; i < COLUMNS_LENGTH; i++)
            {
                if (item.GetIcon(i) == null)
                {
                    item.SetSelectable(i, false);
                }
            }
        }
    }
}
