using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool isOn = false;
    public int activeTime = -1;
    public int startTime = 0;
    public int currentTime = 0;

    public override void OnInteract(GameObject objPlayer)
    {
        if (isOn)
        {
            turnOff();
        }
        else
        {
            turnOn();
        }
        startTime = (int)(TimeManager.time % 60);
    }

    public void turnOff()
    {
        Debug.Log("switch off");
        GetComponent<SpriteRenderer>().color = Color.yellow;
        isOn = false;
    }
    public void turnOn()
    {
        Debug.Log("switch on");
        GetComponent<SpriteRenderer>().color = Color.blue;
        isOn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Time down our switch homie
        if(isOn == true)
        {
            currentTime = (int)(TimeManager.time % 60);
            if((startTime + activeTime) > currentTime)
            {
                //Just continue
            }
            else
            {
                turnOff();
            }
        }
    }
}
