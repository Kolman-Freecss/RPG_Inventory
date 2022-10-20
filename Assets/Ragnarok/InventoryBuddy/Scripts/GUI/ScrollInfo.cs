using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragnarok;
/*
 * ScrollInfo:                  
 * 
 * Attached to the UI element that will display the scroll over info
 * This will find the proper text and populate the text string based off the
 * 
 */

//DevNote: look at renaming to MouseOverDisplay... something else ? title may be a little misleading


public class ScrollInfo : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scrollInfoText;
    private GameObject scrollInfo;
    [HideInInspector]
  //  public bool movingItem; // we want the info off if the player has selected item to move.

    private void Awake()
    {
        scrollInfo = transform.GetChild(0).gameObject;              //reference the child which should have all of the UI elements
        scrollInfo.SetActive(false);                                //make sure the scroll over info UI element is off at startup
        InventoryEvents.ScrollInfoActivated += EnableScrollInfo;    //when the event happens display the scroll over info
        InventoryEvents.ScrollInfoDeactivated += DisableScrollInfo; //when the event happens remove the scroll over info.
    }

    private void Update()
    {
        if (scrollInfo.activeSelf)                          //make sure we are up and running
        {
            transform.position = Input.mousePosition;       //keep the UI attached to the mouses position...soft parenting 
        }
    }

    public void EnableScrollInfo(string text)
    {
        //if (!movingItem)
        //{
            scrollInfoText.text = text;     //get the text from the item
            scrollInfo.SetActive(true);     //turn it on
      //  }

    }

    public void DisableScrollInfo()
    {
        scrollInfoText.text = "null";   //remove text. set text to say null (incase it shows for some reason we will know its in here and will be able to see text)
        scrollInfo.SetActive(false);    //turn it off
    }
}