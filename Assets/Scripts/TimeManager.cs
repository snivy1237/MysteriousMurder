using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static float time;
    public float maxTime;
    public string currentTimeString;
    void Awake() {
        time = 0f;

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        currentTimeString = ReturnTimeReadable();
        
    }


    string ReturnTimeReadable() {
        int sec = (int) (time % 60);
        string secFormatted = "";
        if(sec < 10) {
            secFormatted = "" + 0 + sec;
        } else {
            secFormatted = "" + sec;
        }
        
        int min = (int)  (time % 3600) / 60;
        string minFormatted = "";
        if(min < 10) {
            minFormatted = "" + 0 + min;
        } else {
            secFormatted = "" + sec;
        }

        return "" + minFormatted + ":" + secFormatted;
    }
}
