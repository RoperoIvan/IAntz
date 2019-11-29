using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Worker_Knowledge : MonoBehaviour
{
    public GameObject resource_food;
    public GameObject resource_rocks;
    public GameObject resource_branch;
    public bool on_resource_rock = false;

    //Colliders
    Collider my_coll;
    Collider f_collider;
    Collider r_collider;
    Collider b_collider;

    Bounds my_bounds;
    Bounds f_bounds;
    Bounds r_bounds;
    Bounds b_bounds;

    public GameObject ant_mill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == resource_rocks)
            on_resource_rock = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //The functions of the colliders doesnt work so i will create mine.
        my_coll = this.GetComponent<BoxCollider>();
        r_collider = resource_rocks.GetComponent<BoxCollider>();

        my_bounds = my_coll.bounds;
        r_bounds = r_collider.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Distance_to_rock = resource_rocks.transform.position - this.transform.position;

        if (Distance_to_rock.magnitude <= 3.0f)
            on_resource_rock = true;
    }
}
