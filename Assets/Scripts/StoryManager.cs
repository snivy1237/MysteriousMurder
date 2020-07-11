using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{

    public static bool restaurantClosed = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestaurantCheck();
    }

    void RestaurantCheck() {
        if(TimeManager.time > 180 && TimeManager.time < 360) {
            restaurantClosed = false;
        } else {
            restaurantClosed = true;
        }
    }

    
}
