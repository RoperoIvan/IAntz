using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anthill_Resources : MonoBehaviour
{
    public int Food_cantity = 0;
    public int Rocks_cantity = 0;
    public int Branches_cantity = 0;

    public int Percent_food;
    public int Percent_rocks;
    public int Percent_branches;

    public Text resources_food;
    public Text resources_rocks;
    public Text resources_branches;


    public GameObject you_lose_canvas;

    public GameObject queen;

    public int Total_cantity;
    // Start is called before the first frame update
    void Start()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;

        // UI.
        resources_food.text = "Food:" + Food_cantity;
        resources_rocks.text = "Rocks:" + Rocks_cantity;
        resources_branches.text = "Branches:" + Branches_cantity;

    }

    // Update is called once per frame
    void Update()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;


        //We will do it that way because we want to know the priority, so if we have low food the number will be high, etz...
        Percent_food = Total_cantity - Food_cantity;

        Percent_rocks = Total_cantity - Rocks_cantity;

        Percent_branches = Total_cantity - Branches_cantity;

        // UI.
        resources_food.text = "Food:" + Food_cantity;
        resources_rocks.text = "Rocks:" + Rocks_cantity;
        resources_branches.text = "Branches:" + Branches_cantity;

        if (queen.GetComponent<HealthManager>().current_health == 0)
        {
            you_lose_canvas.SetActive(true);
        }
    }
}
