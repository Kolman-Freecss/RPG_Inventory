using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ragnarok;

/**********************************************************
 * 
 * In Game Item:
 * Place this on all items that you want to be able to pickup and add to an inventory
 * 
 * Put the name of the item and make sure that the spelling matches that item's name on your inventory list
 * 
 *********************************************************/


public class SceneItem : MonoBehaviour
{
    [SerializeField]

    
    private string itemName;  //CASE SENSITIVE - write in the name of the item that matches the name in the InventoryList so we find the right item.
    private InventoryItemList database;
    private bool hasRun;
    private GameObject inventoryFullText;


    // private CollectibleItemSet collectibleItemSet;
    // private UniqueID uniqueID;
    private void Awake()
    {
        inventoryFullText = GameObject.Find("InventoryFull");       //find the game object and make a local reference to it


        //  database = FindObjectOfType<InventoryItemList>();

    }

    void Start()
    {
        //find our InventoryItemList so we can pick our item from the list
    //    database = FindObjectOfType<InventoryItemList>();
     //   Debug.Log(database);


        //    uniqueID = GetComponent<UniqueID>();

        //     collectibleItemSet = FindObjectOfType<CollectibleItemSet>();
        //if (collectibleItemSet.CollectedItems.Contains(uniqueID.ID))
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //        collectibleItemSet.CollectedItems.Add(uniqueID.ID);

            if (!hasRun)
            {
                //add item to the Inventory we want, the players
                //if (other.GetComponent<Inventory>().characterItems.Count < other.GetComponent<Inventory>().inventoryDisplay.numberOfSlots)
                //{
                    other.GetComponent<Inventory>().AddItem(itemName);
                    Destroy(gameObject);  //get rid of item in the game world
                //}
                //else if (other.GetComponent<Inventory>().characterItems.Count == other.GetComponent<Inventory>().inventoryDisplay.numberOfSlots)

                //{
                //    inventoryFullText.SetActive(true);
                //}

                hasRun = true;

                //other.GetComponent<Inventory>().AddItem(itemName);
                

            }

        }
    }
}
