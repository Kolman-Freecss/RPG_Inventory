using UnityEngine;
using System.Collections;
using Ragnarok;

[System.Serializable]                         //    Our Representation of an InventoryItem
public class InventoryItem 
{
    public string itemName = "New Item";      //    What the item will be called in the inventory
    public string itemDescription = "new description";
    //public int MaxStackQuantity = 1;          //how many of this item can stack per slot
    public Sprite itemIcon = null;         //    What the item will look like in the inventory
    public GameObject itemObject;
    public bool isUnique = false;             //    Optional checkbox to indicate that there should only be one of these items per game

    //public bool isIndestructible = false;     //    Optional checkbox to prevent an item from being destroyed by the player (unimplemented)
    //public bool isQuestItem = false;          //    Examples of additional information that could be held in InventoryItem
    //public bool isStackable = false;          //    Examples of additional information that could be held in InventoryItem
    //public bool destroyOnUse = false;         //    Examples of additional information that could be held in InventoryItem
    //public float encumbranceValue = 0;        //    Examples of additional information that could be held in InventoryItem  !!!

    public InventoryItem(InventoryItem item)
    {
        itemName = item.itemName;
        itemDescription = item.itemDescription;
        //MaxStackQuantity = item.MaxStackQuantity;
        itemIcon = item.itemIcon;
        itemObject = item.itemObject;
        isUnique = item.isUnique;
        //isIndestructible = item.isIndestructible;
        //isQuestItem = item.isQuestItem;
        //isStackable = item.isStackable;
        //destroyOnUse = item.destroyOnUse;
        //encumbranceValue = item.encumbranceValue;
    }
}