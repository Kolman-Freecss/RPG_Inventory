using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragnarok;

public class InventoryEvents : MonoBehaviour
{
    public static System.Action<InventoryItem> ItemAddedToInventory; 
    public static System.Action<string> ScrollInfoActivated;
    public static System.Action ScrollInfoDeactivated;
    public static System.Action<InventorySlot> ClickActivated;
    public static System.Action ClickDeactivated;

    //    public static System.Action SaveInitiated;

    //public static void OnItemAddedToInventory(InventoryItem item) //when called, this will create a reference for all the InventoryItems info.
    //{
    //    ItemAddedToInventory.Invoke(item);
    //}

    public static void OnScrollInfoActivated(string text)
    {
        ScrollInfoActivated.Invoke(text);
    }

    public static void OnScrollInfoDeactivated()
    {
        ScrollInfoDeactivated.Invoke();
    }

    //public static void OnClickActivated(InventorySlot slot)
    //{
    //    ClickActivated.Invoke(slot);
    //}

    //public static void OnClickDeactivated()
    //{
    //    ClickDeactivated.Invoke();
    //}
    //public static void OnSaveInitiated()
    //{
    //    SaveInitiated?.Invoke();
    //}
}
