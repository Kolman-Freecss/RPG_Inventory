using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragnarok;

public class ItemsToLoad : MonoBehaviour
{
    private Inventory charInventory;        //Our local characters inventory
    public string[] startingItems;      //the names of all the items we start with

    void Awake()
    {
        charInventory = GetComponent<Inventory>();
    }

    void Start()
    {
        if (charInventory == null)
        {
                throw new System.ArgumentException("An Inventory script is required for this to run");
        }

        for (int i = 0; i < startingItems.Length; i++)
        {
            charInventory.GiveItem(startingItems[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
