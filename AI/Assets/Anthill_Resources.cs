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


    // Base Caps:
    public int Cap_food_basic;
    public int Cap_food_advanced;
    public int Cap_food_end;

    public int Actual_food_storage_lvl;

    public int Af_cap = 0;

    public int Cap_wood_basic;
    public int Cap_wood_advanced;
    public int Cap_wood_end;

    public int Actual_wood_storage_lvl;

    public int Aw_cap = 0;

    public int Cap_rock_basic;
    public int Cap_rock_advanced;
    public int Cap_rock_end;

    public int Actual_rock_storage_lvl;

    public int Ar_cap = 0;

    // Upgrade sound.
    public AudioSource clip;
    public AudioSource clip_error;
    // Ant counts:
    public int worker_count;
    public int warrior_count;


   
    // Start is called before the first frame update
    void Start()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;

        Af_cap = Cap_food_basic;
        Aw_cap = Cap_wood_basic;
        Ar_cap = Cap_rock_basic;

        // UI.
        resources_food.text = "Food: " + Food_cantity + "/" + Af_cap;
        resources_rocks.text = "Rocks: " + Rocks_cantity + "/" + Ar_cap;
        resources_branches.text = "Branches:" + Branches_cantity + "/" + Aw_cap;

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
        resources_food.text = "Food: " + Food_cantity + "/" + Af_cap;
        resources_rocks.text = "Rocks: " + Rocks_cantity + "/" + Ar_cap;
        resources_branches.text = "Branches:" + Branches_cantity + "/" + Aw_cap;

        if (queen.GetComponent<HealthManager>().current_health == 0)
        {
            you_lose_canvas.SetActive(true);
        }

        CapResources();
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

    private void CapResources()
    {
        if (Food_cantity >= Af_cap)
        {
            Food_cantity = Af_cap;
        }

        if (Branches_cantity >= Aw_cap)
        {
            Branches_cantity = Aw_cap;
        }

        if (Rocks_cantity >= Ar_cap)
        {
            Rocks_cantity = Ar_cap;
        }
    }

    public void UpgradeFoodStorage()
    {
        //this var is used to dont double upgrade.
        bool upgraded = false;

 
        // Resources needed to upgrade to tier 2;
        int cantity_to_upgrade_to_tier_2_f = 30;
        int cantity_to_upgrade_to_tier_2_w = 30;
        int cantity_to_upgrade_to_tier_2_r = 30;
        bool can_we_upgrade_lvl_2 = false; ;

        // Resources needed to upgrade to tier 3;
        int cantity_to_upgrade_to_tier_3_f = 40;
        int cantity_to_upgrade_to_tier_3_w = 40;
        int cantity_to_upgrade_to_tier_3_r = 40;
        bool can_we_upgrade_lvl_3 = false;

        //First we need to chech the multiple resources to see if we can upgrade;
        if (cantity_to_upgrade_to_tier_2_f <= Food_cantity && cantity_to_upgrade_to_tier_2_w <= Branches_cantity && cantity_to_upgrade_to_tier_2_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_2 = true;
        }

        if (cantity_to_upgrade_to_tier_3_f <= Food_cantity && cantity_to_upgrade_to_tier_3_w <= Branches_cantity && cantity_to_upgrade_to_tier_3_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_3 = true;
        }


        //If we wanna use other type of resources we need to put new variables;

        if (Actual_food_storage_lvl == 0)
        {
            if (can_we_upgrade_lvl_2)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_2_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_2_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_2_r;

                // Then we upgrade the storage.
                Af_cap = Cap_food_advanced;
                upgraded = true;
                Actual_food_storage_lvl = 1;

                clip.Play();
            }
        }

        if (Actual_food_storage_lvl == 1 && upgraded == false)
        {
            if (can_we_upgrade_lvl_3)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_3_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_3_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_3_r;

                // Then we upgrade the storage.
                Af_cap = Cap_food_end;
                upgraded = true;
                Actual_food_storage_lvl = 2;
                clip.Play();
            }

        }
        if (!can_we_upgrade_lvl_2)
            clip_error.Play();

        if (!can_we_upgrade_lvl_3 && can_we_upgrade_lvl_2) //TODO: Solve this
            clip_error.Play();
    }

    public void UpgradeWoodStorage()
    {
        //this var is used to dont double upgrade.
        bool upgraded = false;


        // Resources needed to upgrade to tier 2;
        int cantity_to_upgrade_to_tier_2_f = 30;
        int cantity_to_upgrade_to_tier_2_w = 30;
        int cantity_to_upgrade_to_tier_2_r = 30;
        bool can_we_upgrade_lvl_2 = false; ;

        // Resources needed to upgrade to tier 3;
        int cantity_to_upgrade_to_tier_3_f = 40;
        int cantity_to_upgrade_to_tier_3_w = 40;
        int cantity_to_upgrade_to_tier_3_r = 40;
        bool can_we_upgrade_lvl_3 = false;

        //First we need to chech the multiple resources to see if we can upgrade;
        if (cantity_to_upgrade_to_tier_2_f <= Food_cantity && cantity_to_upgrade_to_tier_2_w <= Branches_cantity && cantity_to_upgrade_to_tier_2_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_2 = true;
        }

        if (cantity_to_upgrade_to_tier_3_f <= Food_cantity && cantity_to_upgrade_to_tier_3_w <= Branches_cantity && cantity_to_upgrade_to_tier_3_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_3 = true;
        }


        //If we wanna use other type of resources we need to put new variables;

        if (Actual_wood_storage_lvl == 0)
        {
            if (can_we_upgrade_lvl_2)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_2_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_2_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_2_r;

                // Then we upgrade the storage.
                Aw_cap = Cap_food_advanced;
                upgraded = true;
                Actual_wood_storage_lvl = 1;
                clip.Play();
            }
        }

        if (Actual_wood_storage_lvl == 1 && upgraded == false)
        {
            if (can_we_upgrade_lvl_3)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_3_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_3_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_3_r;

                // Then we upgrade the storage.
                Aw_cap = Cap_food_end;
                upgraded = true;
                Actual_wood_storage_lvl = 2;
                clip.Play();
            }

        }
        if (!can_we_upgrade_lvl_2)
            clip_error.Play();

        if (!can_we_upgrade_lvl_3 && can_we_upgrade_lvl_2)
            clip_error.Play();
    }

    public void UpgradeRockStorage()
    {
        //this var is used to dont double upgrade.
        bool upgraded = false;


        // Resources needed to upgrade to tier 2;
        int cantity_to_upgrade_to_tier_2_f = 30;
        int cantity_to_upgrade_to_tier_2_w = 30;
        int cantity_to_upgrade_to_tier_2_r = 30;
        bool can_we_upgrade_lvl_2 = false; ;

        // Resources needed to upgrade to tier 3;
        int cantity_to_upgrade_to_tier_3_f = 40;
        int cantity_to_upgrade_to_tier_3_w = 40;
        int cantity_to_upgrade_to_tier_3_r = 40;
        bool can_we_upgrade_lvl_3 = false;

        //First we need to chech the multiple resources to see if we can upgrade;
        if (cantity_to_upgrade_to_tier_2_f <= Food_cantity && cantity_to_upgrade_to_tier_2_w <= Branches_cantity && cantity_to_upgrade_to_tier_2_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_2 = true;
        }

        if (cantity_to_upgrade_to_tier_3_f <= Food_cantity && cantity_to_upgrade_to_tier_3_w <= Branches_cantity && cantity_to_upgrade_to_tier_3_r <= Rocks_cantity)
        {
            can_we_upgrade_lvl_3 = true;
        }


        //If we wanna use other type of resources we need to put new variables;

        if (Actual_rock_storage_lvl == 0)
        {
            if (can_we_upgrade_lvl_2)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_2_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_2_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_2_r;

                // Then we upgrade the storage.
                Ar_cap = Cap_food_advanced;
                upgraded = true;
                Actual_rock_storage_lvl = 1;
                clip.Play();
            }
        }

        if (Actual_rock_storage_lvl == 1 && upgraded == false)
        {
            if (can_we_upgrade_lvl_3)
            {
                //first we substract the resources , once we know we have more than that.
                Food_cantity -= cantity_to_upgrade_to_tier_3_f;
                Branches_cantity -= cantity_to_upgrade_to_tier_3_w;
                Rocks_cantity -= cantity_to_upgrade_to_tier_3_r;

                // Then we upgrade the storage.
                Ar_cap = Cap_food_end;
                upgraded = true;
                Actual_rock_storage_lvl = 2;
                clip.Play();
            }

        }
        if (!can_we_upgrade_lvl_2)
            clip_error.Play();

        if (!can_we_upgrade_lvl_3 && can_we_upgrade_lvl_2)
            clip_error.Play();
    }



}
