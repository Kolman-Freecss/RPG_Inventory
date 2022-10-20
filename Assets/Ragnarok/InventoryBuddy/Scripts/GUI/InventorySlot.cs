using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Ragnarok;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private Image spriteImage;            //our image inside the slot
    public InventoryItem item;            //our item inside the slot
    public InventorySlot selectedItem;    //reference for our game object "SelectedItem" - so we can change it -
    private TextMeshProUGUI itemNameText; //ref to our slot text
    public bool dropScreen;
    public GameObject dropSpawner;

    [HideInInspector]
    public bool vendor = false;
    [HideInInspector]
    public bool treasureChest = false;
    [HideInInspector]
    public bool inventory = false;
    [HideInInspector]
    public Inventory player;
    [HideInInspector]
    public Inventory tChest;
    

    void Awake()                                                                            //----------runs this once (will happen with the creation of the inventory display)------------
    {
        tChest = GameObject.Find("TreasureChest").GetComponent<Inventory>();
        player = GameObject.Find("FPSController").GetComponent<Inventory>();

        selectedItem = GameObject.Find("SelectedItem").GetComponent<InventorySlot>();       //find the game object named selectedItem and make a local reference to it
        spriteImage = GetComponent<Image>();                                                //setup a reference for our local image component 
        Setup(null);                                                                        //Lets setup the slot to be empty (null) by running the setup
        itemNameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(InventoryItem item)               //-----------------------------------Run this when an inventory slot needs to be updated-----------------------------------------
    {
        this.item = item;                               //this slot will now hold the constructor(InventoryItem item) as its new item

        if (this.item != null)                          //Lets update the slot with our new item's info:
        {
            spriteImage.color = Color.white;            //get the image set up, white will make sure the item looks like its image(i.e. if it were black you couldnt see the image)
            spriteImage.sprite = this.item.itemIcon;    //get the image of our new item and set it in the slot

            if(itemNameText != null)                    //this will be null if we are the selectedItem 
            {
                itemNameText.text = item.itemName;      //put the item's name in the slot
            }
        }
        else                                            //Setup is being ran for the first time on this inventory slot or something pushed Setup(null) through here - which we would want to do when we empty a slot out    
        {
            spriteImage.color = Color.clear;            //This inventory Slot is empty, lets make it clear(alpha set to zero) so we dont see anything.
            if (itemNameText != null)
            {
                itemNameText.text = null;
            }
        }
    }

    //public void Update()
    //{
    //    Debug.Log("tchestEnabled? " + tChest.GetComponent<Inventory>().inventoryDisplay.isActiveAndEnabled);
    //}

    public void OnPointerClick(PointerEventData eventData)                          //-----------------------This inventory slot has been clicked on -------------------------------
    {                                                                               //!!WARNING!!Do not have selectedItem highlighted in the Hierarchy window or it will not update!!WARNING!!
        if (eventData.button == PointerEventData.InputButton.Right)                 // button was right clicked
        {
            if (vendor)                                     //-----------------VENDOR SLOT ------------------------//
            {
                if (this.item != null)                      // is there an item in the slot?
                {
                    player.GiveItem(this.item.itemName);    //add item to player's inventory   
                    Debug.Log("gave to player");
                    if (this.item.isUnique)                 //check if it is unique
                    {
                        Setup(null);                        //if it is, then remove it from vendor's inventory
                        InventoryEvents.OnScrollInfoDeactivated();//remove the mouse over info
                    }
                }
            }                                               //----------------------------------------------------//


         //   if (!inventory)                                                   //----TREASURE CHEST SLOT----------//
         //   {
                if (tChest.GetComponent<Inventory>().inventoryDisplay.isActiveAndEnabled == true)//Is the display active?
                {
                    if (this.item != null)                                        // is there an item in the slot?
                    {
                        if (inventory == true)                                    //im a player inventory slot:
                        {
                            tChest.GiveItem(this.item.itemName);                  //add item to player's treasure chest                  
                        Debug.Log("gave to chest");
                        Setup(null);                                          //remove from inventory
                            InventoryEvents.OnScrollInfoDeactivated();            //remove the mouse over info

                        }
                        if(treasureChest == true)                                 //I am a treasure chest slot:
                        {
                            player.GiveItem(this.item.itemName);                  //add item to player's inventory
                        Debug.Log("gave to player");
                        Setup(null);                                          //remove from treasure chest
                            InventoryEvents.OnScrollInfoDeactivated();            //remove the mouse over info
                        }
                    }                                                             //--------------------------------------//
                }
          //  }




            //          Debug.Log("Right Mouse Button Clicked on: " + name);
            //currently right clicking turns it off... could be a good place to trade item to another inventory display
            //    InventoryEvents.OnClickDeactivated();
        }
        if (eventData.button == PointerEventData.InputButton.Left)                      // User left clicked on this slot
        {
            if (dropScreen)
            {

                if (selectedItem.item != null)
                {
                    Vector3 pos = dropSpawner.transform.position;
                    Quaternion rot = dropSpawner.transform.rotation;
                    Instantiate(selectedItem.item.itemObject, pos, rot);
                    //currently does not remove from inventory...
                    player.GetComponent<Inventory>().RemoveItem(selectedItem.item.itemName);
                    selectedItem.Setup(null);
                    Debug.Log("we've  thrown out the item");
                }
                return;
            }
            else
            {
                if (vendor)
                {
                    //-------check player can afford item here----------------------
                    return; //for now we just dont allow the click to do anything
                }
                if (this.item != null)                                                      //---This slot has an item loaded into it already ---
                {
                    if (selectedItem.item != null)  //put item in here and take out item (swap) if there is one in the slot already
                    {
                        //           Debug.Log("clicked on item");
                        InventoryItem clone = new InventoryItem(selectedItem.item);
                        //           Debug.Log("clone: " + clone.itemName);
                        //           Debug.Log("thisItem: " + this.item.itemName);
                        selectedItem.Setup(this.item);
                        //           Debug.Log("selectedItem.item: " + selectedItem.item.itemName);
                        Setup(clone);

                    }
                    else                           //take the item and leave the slot empty
                    {
                        //           Debug.Log("activate moveable item here");
                        selectedItem.Setup(this.item);
                        Setup(null);
                    }
                }
                else if (selectedItem.item != null)                                         //we have a selected item and we clicked into an empty slot
                {
                    //       Debug.Log("Empty Slot lets put item here");
                    Setup(selectedItem.item);                                               //put the selected items info into this slot
                    selectedItem.Setup(null);                                               //remove the selected item from our selection
                }
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!dropScreen)
        {
            if (item != null)
            {
                if (item.itemDescription != null)
                {
                    InventoryEvents.OnScrollInfoActivated(item.itemDescription);

                }
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!dropScreen)
        {
            InventoryEvents.OnScrollInfoDeactivated();
        }
    }
}






//   public bool selection;
//   public InventorySlot swapItem = null;
//   private SelectedItem selectedItem;
//  private SelectedItem replaceItem;
//  public bool ActiveMovingSlot;
// private InventorySlot selectedItem;
//     private bool empty;
//  public InventoryItem baseItem;
//   private bool hasClicked;
// private TextMeshProUGUI itemNameText;






//void Awake()
//{
//    selectedItem = GameObject.Find("SelectedItem").GetComponent<InventorySlot>();
//    //    selectedItem = FindObjectOfType<SelectedItem>();
//    //     baseItem = new InventoryItem();   //use base item when I am not holding an item
//    //  tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
//    spriteImage = GetComponent<Image>();
//    // this.selectedItem = this;   // -------------------------------------------- turned off seems to be working a bit better... what was this for?
//    //       this.slotItem = baseItem;
//    Setup(null);
//    //   UpdateItem(null);

//    //   selectedItem = GameObject.Find("SelectedItem").GetComponent<InventorySlot>();
//}





////

//swapItem = selectedItem;
//Setup(swapItem.item);
//selectedItem.swapItem = swapItem.swapItem;



//              selectedItem.
////              GameObject.Find("SelectedItem").GetComponent<InventorySlot>().selectedItem = selectedItem;
////              GameObject.Find("SelectedItem").GetComponent<InventorySlot>().selectedItem.Setup(this.item); // = selectedItem;

//            //  Debug.Log(swapItem.item.itemName);
//              selectedItem.Setup(this.item);
//              Setup(swapItem.item);

//////if (this.slotItem != null)                              // this slot has an item in it
//////{
//////    //if (!hasClicked)
//////    //{
//////    if (selectedItem.moveableItem.activeSelf)               // is an item being moved here?         

//////    {                                                       // Yes:
//////        Debug.Log("placing item here");
//////        replaceItem = selectedItem;                         //reference the moveable item
//////        Setup(replaceItem.itemOnMove);                      //setup our moveable item info
//////        selectedItem.itemOnMove = replaceItem.itemOnMove;   //place the selected item into the moving ones slot
//////        this.slotItem = replaceItem.itemOnMove;             // place the movable item into this slot
//////        InventoryEvents.OnClickDeactivated();               //Turn off the Selected item image

//////    }                                                       // No:

//////    else                                                    // pick up the item
//////    {
//////        Debug.Log("activate moveable item here");
//////        InventoryEvents.OnClickActivated(this);             //Turn on the Selected item image
//////        Setup(null);                                        //empty the slot

//////    }
//////}
//////else if (selectedItem.moveableItem.activeSelf)     //this slot has no item in it and an item is being moved
//////{
//////    Debug.Log("Empty Slot lets put item here");
//////    InventoryEvents.OnClickDeactivated();       //Turn off the Selected item image
//////    Setup(slot.slotItem);                       //put the item in the slot
//////    //slot.Setup(null);                           //remove the old slot
//////}

//else    -   this slot has no item in it and no item is being moved

//if (this.SlotItem == baseItem)
//{
//    //this slot has no item so we shouldnt act like we can move the empty slot
//    InventoryEvents.OnClickDeactivated();
//    return;
//}


//if (selectedItem.moveableItem.activeSelf)             // check if a moveable item is active                    
//{
//    replaceItem = selectedItem;                         //reference the moveable item
//    Setup(replaceItem.itemOnMove);                      //setup our moveable item info
//    selectedItem.itemOnMove = replaceItem.itemOnMove;    //place the selected item into the moving ones slot
//    this.SlotItem = replaceItem.itemOnMove;             // place the movable item into this slot





//    if (!ActiveMovingSlot)          //is it the slot of the moving item? No...
//    {
//        //put the item here . im not null so i should swap
//        //swap item positions...


//    }
//    else                             //yes this is the moving item...
//    {
//        //item is aleaady here . dont need to do anything,
//        ActiveMovingSlot = false; //lets turn it off ...maybe? think on this....if its true then we know im clicking on the same one again...
//    }


//    //  Setup(selectedItem.itemOnMove); // setup selectedItems info
//    InventoryEvents.OnClickDeactivated();
//}
//else                                                // no moveable item is active - lets get one going
//{
//    InventoryEvents.OnClickActivated(this);         // tell selected item(drag around image) to show up

//    ActiveMovingSlot = true;//idea here is only the slot that activated the moveableitem will be true


//    // this slot needs to be ready to clear or switch with another
//    // clear it when it is placed into empty slot
//    // swap it when placed into filled slot

//    //this needs a public reference so i can reset the slot. 

//}

//if the slot has something in it swap it with the other position
//    hasClicked = true;
//}
//else
//{
//    InventoryEvents.OnClickDeactivated();
//    hasClicked = false;

//}
// }
//  else                                                    // this button doesn't have an item
//  {
////      this.SlotItem; 
//  }
//  }

//   }
//}

//  if (!empty)
//   {
//  this.SlotItem = item;

//      Debug.Log(this.SlotItem.itemDescription);

//   {
//if (item.itemName != null)
//{
//    itemNameText.text = item.itemName;
//}

//    }
//      Debug.Log(this.SlotItem.itemName);

//if (spriteImage == null)                        //find image incase item was picked up while the inventory menu is disabled  
//{
//    spriteImage = GetComponent<Image>();
//}
//if (spriteImage != null)
//{
//    spriteImage.color = Color.white;
//    spriteImage.sprite = item.itemIcon;
//}
//     empty = false;
//  }
//else
//{
//    this.slotItem = baseItem;
//    if (spriteImage != null)
//    {
//        spriteImage.color = Color.clear;
//        spriteImage.sprite = null;
//    }

//    if (itemNameText != null)
//    {
//        itemNameText.text = null;
//    }         
////    empty = true;

//}

//   }
// }
