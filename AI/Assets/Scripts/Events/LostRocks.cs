﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostRocks : MonoBehaviour
{
    public int waste_percentage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            WastingRocks();
        }
    }

    public void WastingRocks()
    {//TODO: Put condition for level of storage
        int wasted_food;
        waste_percentage = Random.Range(5, 21);
        wasted_food = (waste_percentage * GetComponent<Anthill_Resources>().Rocks_cantity) / 100;
        GetComponent<Anthill_Resources>().Rocks_cantity -= wasted_food;
    }
}