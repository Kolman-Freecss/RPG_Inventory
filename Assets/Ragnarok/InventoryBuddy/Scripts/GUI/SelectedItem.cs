using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ragnarok;

public class SelectedItem : MonoBehaviour
{
    public InventoryItem myItem;



}


//////    [SerializeField]
//////    public GameObject moveableItem;
//////    public InventoryItem itemOnMove;
//////    private Image spriteImage;
//////    private bool newClick;

//////    private ScrollInfo tip;

//////    void Awake()
//////    {
//////        tip = FindObjectOfType<ScrollInfo>();                        //reference to the scroll info So we can control when its on/off
//////        moveableItem = transform.GetChild(0).gameObject;             //reference the child which should have all of the UI elements
//////        spriteImage = moveableItem.GetComponent<Image>();            //reference the image used in our item
//////        moveableItem.SetActive(false);                               //make sure the scroll over info UI element is off at startup
//////        InventoryEvents.ClickActivated += EnableMoveableItem;        //when the event happens run this
//////        InventoryEvents.ClickDeactivated += DisableMoveableItem;     //when the event happens run this

//////    }

//////    private void Update()
//////    {
//////        if (moveableItem.activeSelf)                          //make sure we are up and running
//////        {
//////            transform.position = Input.mousePosition;       //keep the UI attached to the mouses position...soft parenting 
//////            if (newClick)
//////            {


//////            }
//////        }
//////    }

//////    public void EnableMoveableItem(InventorySlot item)
//////    {
//////        itemOnMove = item.slotItem;
//////        tip.movingItem = true;          //tell the scroll over tip that we are moving an item, keeps the tip off so it looks a bit cleaner.
//////                                        //   Debug.Log("EnableMoveableItem");
//////                                        //    InventoryEvents.ScrollInfoDeactivated();        //Turn off the scroll over  @@@@@This works for turning it off, but it will turn back on when scrolled over again, this needs to be somewhere else @@@
//////        moveableItem.SetActive(true);                   //turn it on
//////        spriteImage.color = Color.white;                //make sure its white, so we get best colors       
//////        spriteImage.sprite = item.slotItem.itemIcon;    //find the image to use for our item


//////    }

//////    public void DisableMoveableItem()
//////    {
//////        tip.movingItem = false;
//////        //    Debug.Log("disableMoveableItem");
//////        moveableItem.SetActive(false);     //turn it off

//////    }
//////}
