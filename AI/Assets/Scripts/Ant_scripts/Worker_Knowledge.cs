using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Worker_Knowledge : MonoBehaviour
{
    public GameObject resource_food;
    public GameObject resource_rocks;
    public GameObject resource_branch;
    public GameObject sleep_module;
    public bool on_resource_rock = false;
    public bool on_storage = false;
    public bool on_resource_food = false;
    public bool on_resource_branches = false;
    public bool on_sleep_module = false;

    public int priority_food;
    public int priority_rocks;
    public int priority_branches;

    public LayerMask enemies_layer;

    public int my_load; //0 nothing 1 food 2 rocks 3 branches.

    public bool day;

    public int current_food;


    //Colliders

    public GameObject My_nearest_enemie;

    public GameObject ant_mill;

    public GameObject anthill_resources;

    private Anthill_Resources ant_res;

    private Day_night life_cycle;


    // Start is called before the first frame update
    void Start()
    {
        ant_res = anthill_resources.GetComponent<Anthill_Resources>();
        life_cycle = anthill_resources.GetComponent<Day_night>();

        priority_branches = ant_res.Percent_branches;
        priority_food = ant_res.Percent_food;
        priority_rocks = ant_res.Percent_rocks;
        my_load = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //every time we start a cycle we wanna reset our variables.
        day = life_cycle.day;

        on_resource_rock = false;
        on_storage = false;
        on_resource_food = false;
        on_resource_branches = false;
        on_sleep_module = false;

        //Distances --------------------------------------------------------------------------------------------------
        Vector3 Distance_to_rock = resource_rocks.transform.position - this.transform.position;
        Vector3 Distance_to_storage = ant_mill.transform.position - this.transform.position;
        Vector3 Distance_to_food = resource_food.transform.position - this.transform.position;
        Vector3 Distance_to_branches = resource_branch.transform.position - this.transform.position;
        Vector3 Distance_to_smodule = sleep_module.transform.position - this.transform.position;

        if (Distance_to_branches.magnitude <= 3.0f)
            on_resource_branches = true;

        if (Distance_to_food.magnitude <= 3.0f)
            on_resource_food = true;

        if (Distance_to_rock.magnitude <= 3.0f)
            on_resource_rock = true;

        if (Distance_to_storage.magnitude <= 3.0f)
        {
            CalculatePriorities(); //this way looks more real, the ant only knows what is missing if he is at the anthill :D
            on_storage = true;
        }

        if (Distance_to_smodule.magnitude <= 3.0f)
        {
            on_sleep_module = true;
        }

        //Distances --------------------------------------------------------------------------------------------------
        current_food = ant_res.Food_cantity;


        //Calc of my nearest enemie.

        Collider[] colliders = Physics.OverlapSphere(transform.position, 10.0f, enemies_layer);

        foreach(Collider col in colliders)
        {
            if (My_nearest_enemie == null)
                My_nearest_enemie = col.gameObject;
            else
            {
                Vector3 dist_to_ene = col.gameObject.transform.position - this.transform.position;
                Vector3 dist_to_my_ene = My_nearest_enemie.transform.position - this.transform.position;

                if (dist_to_my_ene.magnitude > dist_to_ene.magnitude)
                    My_nearest_enemie = col.gameObject;
            }
        }
    }

    public void CalculatePriorities()
    {
        priority_branches = ant_res.Percent_branches;
        priority_food = ant_res.Percent_food;
        priority_rocks = ant_res.Percent_rocks;
    }

    public void GiveMaterial(int i)
    {
        if (i == 1)
             ant_res.Food_cantity += 10;

        if (i == 2)
             ant_res.Rocks_cantity += 10;

        if (i == 3)
             ant_res.Branches_cantity += 10;

        if (i == 8)
            ant_res.Food_cantity -= 10;
    }
}
