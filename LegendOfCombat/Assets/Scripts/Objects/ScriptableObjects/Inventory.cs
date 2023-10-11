using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfNormalKeys;
    public int numberOfDungeonKeys;

    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.isKey)
        {
            numberOfNormalKeys++;
        }
        else if (itemToAdd.isDungeonKey)
        {
            numberOfDungeonKeys++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
