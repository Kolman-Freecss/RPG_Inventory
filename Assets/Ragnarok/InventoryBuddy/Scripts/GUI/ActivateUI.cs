using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragnarok;

public class ActivateUI : MonoBehaviour
{
  //  public string buttonToPress = "I";
    public KeyCode keyCode;
    public GameObject uIToToggle;
    bool waiting;
    public bool startOff;

    // Start is called before the first frame update
    void Start()
    {
        if (startOff)
        {
            uIToToggle.SetActive(false);
        }

      //  keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), buttonToPress);
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            if (Input.GetKeyDown(keyCode))
            {
                uIToToggle.SetActive(!uIToToggle.activeSelf);
            }
        }
    }
}
