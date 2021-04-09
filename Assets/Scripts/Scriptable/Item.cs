using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable/newItem")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;
    public bool equip;
    public int price;
    public float AttackBouns;
    public float DefendBouns;
    public float healingBouns;
    // Start is called before the first frame update
  
}
