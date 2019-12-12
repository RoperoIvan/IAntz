using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anthill_Resources : MonoBehaviour
{
    public int Food_cantity = 0;
    public int Rocks_cantity = 0;
    public int Branches_cantity = 0;

    public int Percent_food = 1;
    public int Percent_rocks = 1;
    public int Percent_branches = 1;

    public int Priority_food = 3;
    public int Priority_rocks = 1;
    public int Priority_branches = 1;

    public Text resources_food;
    public Text resources_rocks;
    public Text resources_branches;


    public GameObject you_lose_canvas;

    public GameObject queen;

    public int Total_cantity;



    //Base Resource Managment.
    public GameObject Rock_b_1;
    public GameObject Rock_b_2;
    public GameObject Rock_b_3;

    public GameObject Food_b_1;
    public GameObject Food_b_2;
    public GameObject Food_b_3;

    public GameObject Wood_b_1;
    public GameObject Wood_b_2;
    public GameObject Wood_b_3;

    public int Rock_c_1;
    public int Rock_c_2;
    public int Rock_c_3;

    public int Food_c_1;
    public int Food_c_2;
    public int Food_c_3;

    public int Wood_c_1;
    public int Wood_c_2;
    public int Wood_c_3;

    // Start is called before the first frame update
    void Start()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;

        // UI.
        resources_food.text = "Food:" + Food_cantity;
        resources_rocks.text = "Rocks:" + Rocks_cantity;
        resources_branches.text = "Branches:" + Branches_cantity;
        CalculatePriorities();
    }

    // Update is called once per frame
    void Update()
    {
        //Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;


        ////We will do it that way because we want to know the priority, so if we have low food the number will be high, etz...
        //Percent_food = Total_cantity - Food_cantity;

        //Percent_rocks = Total_cantity - Rocks_cantity;

        //Percent_branches = Total_cantity - Branches_cantity;

        if (Input.GetKeyDown("p"))
        {
            Rocks_cantity += 100;
        }

        if (Input.GetKeyDown("o"))
        {
            Food_cantity += 100;
        }

        if (Input.GetKeyDown("i"))
        {
            Branches_cantity += 100;
        }


        // UI.
        resources_food.text = "Food:" + Food_cantity;
        resources_rocks.text = "Rocks:" + Rocks_cantity;
        resources_branches.text = "Branches:" + Branches_cantity;

        if (queen.GetComponent<HealthManager>().current_health == 0)
        {
            you_lose_canvas.SetActive(true);
        }

        CheckResources();
    }

    //public void ChangePriority(int resource, int priority)
    //{
    //    //int resource = 90;
    //    //int priority = 0;

    //    switch (resource)
    //    {
    //        case 0: //Food
    //            Percent_food = priority;
    //            break;
    //        case 1: //Rocks
    //            Percent_rocks = priority;
    //            break;
    //        case 2: //Wood
    //            Percent_branches = priority;
    //            break;
    //        default:
    //            Debug.Log("This resource doesn't exist");
    //            break;
    //    }
    //    CalculatePriorities();
    //}

    public void CalculatePriorities()
    {
        int Totalpriority = Priority_food + Priority_branches + Priority_rocks;

        Percent_food = (Priority_food * 100) / Totalpriority;
        Percent_rocks = (Priority_rocks * 100) / Totalpriority;
        Percent_branches = (Priority_branches * 100) / Totalpriority;
    }

    private void CheckResources()
    {
        //First we set to false all the gameobjects.

        Rock_b_1.SetActive(false);
        Rock_b_2.SetActive(false);
        Rock_b_3.SetActive(false);

        Food_b_1.SetActive(false);
        Food_b_2.SetActive(false);
        Food_b_3.SetActive(false);

        Wood_b_1.SetActive(false);
        Wood_b_2.SetActive(false);
        Wood_b_3.SetActive(false);

        //Then we check if we are over the first quantity.
        if (Rocks_cantity >= Rock_c_1)
        {
            Rock_b_1.SetActive(true);
            //Theb we check if we are over the second check.
            if (Rocks_cantity >= Rock_c_2)
            {
                Rock_b_2.SetActive(true);
                //Last we check the if we are over the third.
                if (Rocks_cantity >= Rock_c_3)
                {
                    Rock_b_3.SetActive(true);
                }
            }
        }

        //Then we check if we are over the first quantity.
        if (Food_cantity >= Food_c_1)
        {
            Food_b_1.SetActive(true);
            //Theb we check if we are over the second check.
            if (Food_cantity >= Food_c_2)
            {
                Food_b_2.SetActive(true);
                //Last we check the if we are over the third.
                if (Food_cantity >= Food_c_3)
                {
                    Food_b_3.SetActive(true);
                }
            }
        }

        //Then we check if we are over the first quantity.
        if (Branches_cantity >= Wood_c_1)
        {
            Wood_b_1.SetActive(true);
            //Theb we check if we are over the second check.
            if (Branches_cantity >= Wood_c_2)
            {
                Wood_b_2.SetActive(true);
                //Last we check the if we are over the third.
                if (Branches_cantity >= Wood_c_3)
                {
                    Wood_b_3.SetActive(true);
                }
            }
        }
    }
}
