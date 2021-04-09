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
