using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthill_Resources : MonoBehaviour
{
    public int Food_cantity = 0;
    public int Rocks_cantity = 0;
    public int Branches_cantity = 0;

    public int Percent_food;
    public int Percent_rocks;
    public int Percent_branches;

    public int Total_cantity;
    // Start is called before the first frame update
    void Start()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;

    }

    // Update is called once per frame
    void Update()
    {
        Total_cantity = Food_cantity + Rocks_cantity + Branches_cantity;


        //We will do it that way because we want to know the priority, so if we have low food the number will be high, etz...
        Percent_food = Total_cantity - Food_cantity;

        Percent_rocks = Total_cantity - Rocks_cantity;

        Percent_branches = Total_cantity - Branches_cantity;
    }
}
