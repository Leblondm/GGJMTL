using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public enum ItemTypes {
        SCISSOR
    }
    private Dictionary<ItemTypes, int> inventory = new Dictionary<ItemTypes, int>();


    public bool hasItem(ItemTypes item) {
        if (!inventory.ContainsKey(item)) {
            return false;
        }

        return inventory[item] > 0;
    }
}
