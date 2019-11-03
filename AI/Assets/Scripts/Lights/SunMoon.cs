using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public GameObject UI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!UI.GetComponent<Day_night>().day)
        {
           
        }
        else
        {
        }
    }
}
