using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public enum ItemTypes {
        Desk1
    }
    private Dictionary<ItemTypes, int> inventory = new Dictionary<ItemTypes, int>();


    public bool hasItem(ItemTypes item) {
        if (!inventory.ContainsKey(item)) {
            return false;
        }

        return inventory[item] > 0;
    }

    public void addItem(ItemTypes item) {
        if (!inventory.ContainsKey(item)) {
            inventory.Add(item, 1);
        }
        inventory[item]++;
    }
}
