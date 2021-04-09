﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Scriptable/newInventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();

}
