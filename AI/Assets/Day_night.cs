using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Day_night : MonoBehaviour
{
    public bool day = true;
    public Light sun_light;
    Color color_day = Color.yellow;
    Color color_night = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (sun_light.transform.position.y <= 65f && sun_light.transform.position.y >= -144f)
        {
            //sun_light.color = Color.Lerp(color_night, color_day, 2);
            //Debug.Log("The Sun rises again my childs, Praise the sun");
            day = false;
        }
        else if(sun_light.transform.position.y <= 300f && sun_light.transform.position.y >= 86f)
        {
            day = true;
        }
    }


    public void Daynight()
    {

        //day = !day;
   
        //if(day)
        //{
        //    sun_light.color = Color.Lerp(color_night, color_day, 2);
        //    Debug.Log("The Sun rises again my childs, Praise the sun");
        //}
        //else
        //{
        //    sun_light.color = Color.Lerp(color_day, color_night, 2);
        //    Debug.Log("The night devoures the world, let the darkness be one with you");
        //}
    }
}
