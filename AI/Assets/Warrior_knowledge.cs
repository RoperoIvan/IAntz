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

    private List<GameObject> detected;
    private List<GameObject> detected_now;
    public GameObject My_current_enemy;

    public LayerMask enemies_layer;

    public bool player_detected = false;

    public float detection_radius = 20f;
    public bool day;
    private Day_night life_cycle;
    AIVision my_vision;
    // Start is called before the first frame update
    void Start()
    {
        life_cycle = resources.GetComponent<Day_night>();
        res = resources.GetComponent<Anthill_Resources>();
        detected = new List<GameObject>();
        detected_now = new List<GameObject>();
        my_vision = this.GetComponent<AIVision>();
    }

    // Update is called once per frame
    void Update()
    {

        My_current_enemy = null;
        My_current_enemy = my_vision.current_enemy;
        day = life_cycle.day;

        current_food = res.Food_cantity;

        on_sleep_module = false;

        Vector3 dist_to_mod = Where_to_rest.transform.position - this.transform.position;


        if (dist_to_mod.magnitude < 6.0f)
            on_sleep_module = true;

       
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detection_radius);
    }
}

