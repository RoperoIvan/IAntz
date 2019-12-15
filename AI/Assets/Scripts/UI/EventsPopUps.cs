using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsPopUps : MonoBehaviour
{
    public GameObject food_text;
    public GameObject rocks_text;
    public GameObject wood_text;
    public GameObject raid_text;
    public GameObject resources;
    public GameObject spawn;
    public float timer = 5.0f;
    bool countdown = false;
    // Start is called before the first frame update
    void Start()
    {
        //food_text.GetComponent<Text>().text = "Part of your food has been spoiled \n by the poor state of your storage. \n Level it up so it doesn't happen.";
        //rocks_text.GetComponent<Text>().text = "Some stones have been lost, you may have to level up your storage.";
        //wood_text.GetComponent<Text>().text = "Some wood have been lost, you may have to level up your storage.";
        //timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {      
        if (resources.GetComponent<LostFood>().is_wasted)
        {
            food_text.SetActive(true);
            resources.GetComponent<LostFood>().is_wasted = false;
            countdown = true;
        }
        if (resources.GetComponent<LostWood>().is_wasted)
        {
            wood_text.SetActive(true);
            resources.GetComponent<LostWood>().is_wasted = false;
            countdown = true;
        }
        if (resources.GetComponent<LostRocks>().is_wasted)
        {
            rocks_text.SetActive(true);
            resources.GetComponent<LostRocks>().is_wasted = false;
            countdown = true;
        }
        if (spawn.GetComponent<SpawnEnemies>().clicked)
        {
            raid_text.SetActive(true);
            spawn.GetComponent<SpawnEnemies>().clicked = false;
            countdown = true;
        }
        if (countdown)
            CountDown();
    }

    void CountDown()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && resources.GetComponent<LostFood>().is_wasted == false && resources.GetComponent<LostWood>().is_wasted == false && spawn.GetComponent<SpawnEnemies>().clicked == false)
        {
            food_text.SetActive(false);
            wood_text.SetActive(false);
            rocks_text.SetActive(false);
            raid_text.SetActive(false);
            countdown = false;
            timer = 5;
        }
    }
}
