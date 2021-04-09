using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public TMP_Text slotNum;
   
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
}
