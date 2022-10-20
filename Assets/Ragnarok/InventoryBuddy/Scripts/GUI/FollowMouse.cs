using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ragnarok;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Input.mousePosition;       //keep the UI attached to the mouses position...soft parenting 
    }
}
