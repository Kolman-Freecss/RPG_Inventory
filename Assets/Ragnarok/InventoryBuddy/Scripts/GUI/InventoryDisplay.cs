using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Ragnarok;

public class InventoryDisplay : MonoBehaviour
{
    //  private const int MAXIMUM_SLOTS_IN_INVENTORY = 10;

    //  public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

    [SerializeField]
    // private InventorySlot uiItem;

    public List<InventorySlot> uIItems = new List<InventorySlot>();
    public GameObject slotPrefab;
    public Transform slotGrid;
    public int numberOfSlots = 24;
    public bool vendor;
    public bool TreasureChest;
    public bool player;

    void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotGrid);

            //setup what type of inventory this is...currently using bools may want to make it type list...
            if (vendor)
            {
                instance.GetComponentInChildren<InventorySlot>().vendor = true;
            }
            if (TreasureChest)
            {
                instance.GetComponentInChildren<InventorySlot>().treasureChest = true;
            }
            if (player)
            {
                instance.GetComponentInChildren<InventorySlot>().inventory = true;
            }
            uIItems.Add(instance.GetComponentInChildren<InventorySlot>());
        }


        //   InventoryEvents.ItemAddedToInventory += AddUIItem;  //when the event happens add another ui item

    }

    private void Update()
    {
        //     Debug.Log("UI slot count: " + uIItems.Count);
        //  Debug.Log()
    }

    public void SetupSlot(int slot, InventoryItem item)
    {
        uIItems[slot].Setup(item);

    }

    public void AddNewItem(InventoryItem item)
    {
        SetupSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(InventoryItem item)
    {
        SetupSlot(uIItems.FindIndex(i => i.item == item), null);
    }
}
        //InventorySlot uIItemInstance = Instantiate(uiItem, this.transform);
        //uIItemInstance.Setup(item);
        //Debug.Log("UI Item Event ");

        //int quantityToAdd = 6;
        //Debug.Log(InventoryRecords.Count);

        //while (quantityToAdd > 0)
        //{
        //    // If an object of this item type already exists in the inventory, and has room to stack more items,
        //    // then add as many as we can to that stack.
        //    if (InventoryRecords.Exists(x => (x.iItem.itemName == item.itemName) && (x.Quantity < item.MaxStackQuantity)))
        //    {
        //        // Get the item we're going to add quantity to
        //        InventoryRecord inventoryRecord =
        //        InventoryRecords.First(x => (x.iItem.itemName == item.itemName) && (x.Quantity < item.MaxStackQuantity));

        //        // Calculate how many more can be added to this stack
        //        int maximumQuantityYouCanAddToThisStack = (item.MaxStackQuantity - inventoryRecord.Quantity);

        //        // Add to the stack (either the full quanity, or the amount that would make it reach the stack maximum)
        //        int quantityToAddToStack = System.Math.Min(quantityToAdd, maximumQuantityYouCanAddToThisStack);

        //        inventoryRecord.AddToQuantity(quantityToAddToStack);

        //        // Decrease the quantityToAdd by the amount we added to the stack.
        //        // If we added the total quantityToAdd to the stack, then this value will be 0, and we'll exit the 'while' loop.
        //        quantityToAdd -= quantityToAddToStack;
        //    }
        //    else
        //    {
        //        // We don't already have an existing inventoryRecord for this ObtainableItem object,
        //        // so, add one to the list, if there is room.
        //        if (InventoryRecords.Count < MAXIMUM_SLOTS_IN_INVENTORY)
        //        {
        //            // Don't set the quantity value here.
        //            // The 'while' loop will take us back to the code above, which will add to the quantity.
        //            InventoryRecords.Add(new InventoryRecord(item, 0));
        //        }
        //        else
        //        {
        //            // Throw an exception, or somehow let the user know they are out of inventory space.
        //            // This exception here is just a quick example. Do something better in your code.
        //            throw new System.Exception("There is no more space in the inventory");
        //        }
        //    }
        //}
        //Debug.Log(InventoryRecords.Count + " end");
  //  }

    //public class InventoryRecord
    //{
    //    public InventoryItem iItem { get; private set; }
    //    public int Quantity { get; private set; }

    //    public InventoryRecord(InventoryItem item, int quantity)
    //    {
    //        iItem = item;
    //        Quantity = quantity;
    //    }

    //    public void AddToQuantity(int amountToAdd)
    //    {
    //        Quantity += amountToAdd;
    //    }
    //}
//}
