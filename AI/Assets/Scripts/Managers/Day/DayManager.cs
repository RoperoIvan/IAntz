using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public bool next_day = false;
    public Light sun_light;
    public GameObject NextDay;
    public GameObject Text;
    public int days_until_winter = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GetComponent<Day_night>().day)
        {            
            next_day = true;
            NextDay.SetActive(true);
            Text.GetComponent<Text>().text = days_until_winter + " days until winter comes";
        }
    }

    public void GoToNextDay()
    {
        days_until_winter--;
        next_day = false;
        NextDay.SetActive(false);
        this.GetComponent<Day_night>().day = true;
        Vector3 day_pos = new Vector3(0f, 128.2342f, -295.3641f);
        sun_light.transform.position = day_pos;
        GetComponent<EventManager>().lets_calculate_event = false;
    }
}
