using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool have_been_attacked = false;
    public bool lets_calculate_event = false;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Day_night>().day && !lets_calculate_event)
        {
            CalculateEvent();
            lets_calculate_event = true;
        }
    }

    public void CalculateEvent()
    {
        int there_is_event;
        there_is_event = Random.Range(0, 2);
         if(there_is_event != 0)
        {
            ChooseEvent();
        }
    }

    public void ChooseEvent()
    {
        int max_events;
        if (have_been_attacked)
            max_events = Random.Range(0, 3);
        else
            max_events = Random.Range(0, 4);

        switch(max_events)
        {
            case 0: //Waste Food
                Debug.Log("Wasting Food");
                GetComponent<LostFood>().WastingFood();
                break;
            case 1: //Waste Rocks
                Debug.Log("Wasting Rocks");
                GetComponent<LostRocks>().WastingRocks();
                break;
            case 2: //Waste Wood
                Debug.Log("Wasting Wood");
                GetComponent<LostWood>().WastingWood();
                break;

            case 3: //Attack Enemies
                Debug.Log("Raid");
                spawn.GetComponent<SpawnEnemies>().Clicked();
                break;
            default:
                Debug.Log("This shouldn't happen, something has to be really REALLY broke.");               
                break;
        }
    }
}
