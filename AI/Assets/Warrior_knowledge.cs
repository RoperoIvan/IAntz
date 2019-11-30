using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_knowledge : MonoBehaviour
{
    public GameObject Where_to_rest;
    public bool on_sleep_module = false;

    public int current_food;

    public GameObject resources;

    private Anthill_Resources res;




    // Start is called before the first frame update
    void Start()
    {
        res = resources.GetComponent<Anthill_Resources>();
    }

    // Update is called once per frame
    void Update()
    {
        current_food = res.Food_cantity;

        on_sleep_module = false;


        Vector3 dist_to_mod = Where_to_rest.transform.position - this.transform.position;


        if (dist_to_mod.magnitude < 3.0f)
            on_sleep_module = true;
    }
}
