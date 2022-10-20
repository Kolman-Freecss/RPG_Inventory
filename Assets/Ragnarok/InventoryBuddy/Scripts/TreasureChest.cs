using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public List<GameObject> players; //player distance check is made using this, attach this to the players
    GameObject[] playersToAdd;
    GameObject playerToCheck;

    public float openRange;//set the size of the open trigger
    public bool showOpenRange;
    private ActivateUI myUI;



    // Start is called before the first frame update
    private void Awake()
    {
        myUI = GetComponentInChildren<ActivateUI>();
        myUI.enabled = false;
    }
    void Start()
    {
        playersToAdd = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in playersToAdd)
        {
            players.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerToCheck = players[i]; //reference the current object in the loop
            if (Vector3.Distance(transform.position, playerToCheck.transform.position) < openRange)
            {
                myUI.enabled = true;
            }
            else
            {
                myUI.enabled = false;
                myUI.uIToToggle.SetActive(false);
            }
        }
    }
    void OnDrawGizmos()
    {
        if (showOpenRange == true)
        {
            if (openRange <= 0) return;
            Gizmos.color = new Color(1, 0, 0, 0.1f);//red
            Gizmos.DrawSphere(transform.position, openRange);
        }
    }
}
