using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnSale : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public GameObject EnterDialog;
    public float currentTime = 2f;
    // 弹幕计时
    private float invokeTime;
    private bool dialogueShow;
    private TMP_Text itemPrice;
    public TMP_Text itemInfo;
    private bool itemChecked;
    public static bool coinChanged;
    public ScriptableHero thisHero;


    private void Awake()
    {
        itemPrice =GetComponentInChildren<TMP_Text>();
        itemPrice.text = thisItem.price+"";
    }
    private void Update()
    {

        hideDialogue();
   

        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               *//* if (hit.transform.gameObject.tag == "Item")
                {*//*
                    AddNewItem();
                    Destroy(gameObject);
               *//* }*/
        /* else
         {
             Debug.Log(hit.transform.gameObject.tag);
         }*//*
     }
 }*/

    }
    private void Start()
    {
        invokeTime = currentTime;
        
    }
    public void itemEquip()
    {
        if (thisItem.equip == true)
        {
  

            if (thisItem.itemHasEffect == false)
            {

                thisHero.defend += thisHero.defend * (thisItem.DefendBouns / 100);
                thisHero.attack += thisHero.attack * (thisItem.AttackBouns / 100);
                switch (thisItem.id)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:

                        break;
                    case 4:
                        thisHero.HP += thisItem.healingBouns/100;
                        BaseHero.updateHP = true;
                        break;
                    case 5:
                        BaseHero.canCriticalStrike = true;
                        break;
                    case 7:
                        BaseHero.maxHPChangedNumber = thisItem.healthBouns / 1000;
                        BaseHero.maxHPChanged = true;
                        break;
                    case 8:
                        thisHero.HP += thisItem.healingBouns / 1000;
                        BaseHero.updateHP = true;
                        break;
                    case 9:
                        BaseHero.maxHPChangedNumber = thisItem.healthBouns / 1000;
                        BaseHero.maxHPChanged = true;
                        thisHero.healamount = thisHero.healamount * 2;
                        break;
                    case 10:
                        BaseHero.canLifeSteal = true;
                        BaseHero.lifestealRate = 0.2f;
                        break;
                    case 11:
                        BaseHero.monkeyKingBarEquipped = true;
                        break;
                    case 12:
                        thisHero.HP += thisItem.healingBouns / 1000;
                        BaseHero.updateHP = true;
                        break;
                }
                thisItem.itemHasEffect = true;
            }
        }
    }
    public void itemClicked()
    {
        if (!itemChecked)
        {
            itemInfo.text = thisItem.itemInfo;
            itemChecked = true;

        }
        else {

            if (thisHero.coinnumber < thisItem.price)
            {
                EnterDialog.SetActive(true);
                dialogueShow = true;

            }
            else
            {
                thisHero.coinnumber -= thisItem.price;
                coinChanged = true;
                thisItem.equip = true;
                itemEquip();

                AddNewItem();
                Destroy(gameObject);
            }
            itemChecked = false;
        }
    }
    public void hideDialogue()
    {
        if (dialogueShow)
        {

            invokeTime += Time.deltaTime;

            if (invokeTime - currentTime > 0)
            {
                EnterDialog.SetActive(false);

                invokeTime = 0;
                dialogueShow = false;
            }

           
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
          /*  InventoryManager.CreateNewItem(thisItem);*/
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }

}
