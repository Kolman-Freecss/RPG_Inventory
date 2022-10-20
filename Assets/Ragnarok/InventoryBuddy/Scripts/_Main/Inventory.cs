using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ragnarok //this creates a namespace for all of the Ragnarok scripts so they dont interfere with yours
{
    /*******************************************************
     * 
     * Inventory:
     * 
     * Use this on your player/vendor...whatever game object will own an inventory of their own
     * 
     * Set the database we want to pull item info from(most likely the one that has all of our items listed(the asset created with InventoryBuddy))
     * 
     * 
     * 
     * 
     *******************************************************/

    public class Inventory : MonoBehaviour
    {
        public List<InventoryItem> characterItems = new List<InventoryItem>();  //create a new list called items                                                                             
        public InventoryItemList database;                                      //pick the list we want to get info from
        public InventoryDisplay inventoryDisplay;


        private void Start()
        {

            //    GiveItem("Red Ball");
            //    GiveItem("Orange Ball");
            //GiveItem("Red Ball");
            //GiveItem("Orange Ball");
            //GiveItem("Red Ball");
            //GiveItem("Red Ball");
            //GiveItem("Orange Ball");
            //GiveItem("Orange Ball");
            //InventoryEvents.SaveInitiated += Save;
            //Load();
        }

        private void Update()
        {
            //--------fill up the whole inventory-----------------------//
            //if (characterItems.Count < inventoryDisplay.numberOfSlots)
            //{
            //    Debug.Log(characterItems.Count);
            //    GiveItem("Red Ball");
            //}
            //---------------------------------------------------------//

            //  Debug.Log("char inventory - items count: " + characterItems.Count);
        }

        public void GiveItem(string itemName)
        {
            InventoryItem itemToAdd = database.GetItem(itemName);
            characterItems.Add(itemToAdd);
          //  Debug.Log("gave item:" + itemToAdd.itemName);
            inventoryDisplay.AddNewItem(itemToAdd);         //add the item to the inventory display

        }

        public void AddItem(string itemName)
        {
            InventoryItem itemToAdd = database.GetItem(itemName);   //get reference to our listed item
            characterItems.Add(itemToAdd);                                   //add reference to our local items list
            inventoryDisplay.AddNewItem(itemToAdd);
            //     InventoryEvents.OnItemAddedToInventory(itemToAdd);      //call event using our referenced item, the event will tell the display to show it.
            //   Debug.Log("Item addded: " + itemToAdd.itemName);
        }

        public void AddItems(List<InventoryItem> items)
        {
            foreach (InventoryItem item in items)
            {
                AddItem(item.itemName);
            }
        }

        public InventoryItem CheckThisItem(string itemName)
        {
            return characterItems.Find(InventoryItem => InventoryItem.itemName == itemName);
        }


        public void RemoveItem(string itemName)
        {
            InventoryItem item = CheckThisItem(itemName);
            if (item != null)
            {
                characterItems.Remove(item);
                Debug.Log("Item removed: " + item.itemName);
            }
        }
        //void Save()
        //{
        //    SaveLoad.Save<List<InventoryItem>>(Items, "Inventory");
        //}

        //void Load()
        //{
        //    if (SaveLoad.SaveExists("Inventory"))
        //    {
        //        AddItems(SaveLoad.Load<List<InventoryItem>>("Inventory"));
        //    }
        //}
    }
}

