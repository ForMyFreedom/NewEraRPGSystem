using Godot;
using Godot.Collections;
using System;

public class CharacterInventory: Node
{
    private Array<InventoryItem> itens;
    private int selectedWeaponItemIndex;



    public Weapon GetSelectedWeapon()
    {
        if (selectedWeaponItemIndex == -1) return null;
        return (Weapon) itens[selectedWeaponItemIndex];
    }

    public int GetSelectedWeaponDamage()
    {
        if (selectedWeaponItemIndex == -1) return 0;
        return GetSelectedWeapon().GetDamage();
    }

    public int GetSelectedWeaponIndex()
    {
        return selectedWeaponItemIndex;
    }

    public void SetSelectedWeaponIndex(int index)
    {
        selectedWeaponItemIndex = index;
    }

    public void SetItens(Array<InventoryItem> _itens)
    {
        itens = _itens;
    }

    public Array<InventoryItem> GetItens()
    {
        return itens;
    }
}
