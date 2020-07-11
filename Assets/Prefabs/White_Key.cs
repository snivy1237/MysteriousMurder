using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class White_Key : Interactable
{

    public override void OnInteract(GameObject objPlayer)
    {
        //Add White Key to player Inventory
        objPlayer.GetComponent<Player>().whiteKey = true;
        Debug.Log("Got the White KEY !");
        //Delete White Key Item
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
