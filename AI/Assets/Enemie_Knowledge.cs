using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Knowledge : MonoBehaviour
{
    //Vars:
    //GameObjects:
    public GameObject Queen;
    public GameObject My_current_enemy;
    public GameObject enemi_anthill;
    public GameObject My_spawn;

    public GameObject Notonmywatch;
    
    public bool day;
    

    AIVision my_vision;
    private Day_night life_cycle;

    // Start is called before the first frame update

    void Start()
    {
        life_cycle = enemi_anthill.GetComponent<Day_night>();
        my_vision = this.GetComponent<AIVision>();
    }

    // Update is called once per frame
    void Update()
    {
        day = life_cycle.day;

        My_current_enemy = Notonmywatch;
        if (my_vision.current_enemy != null)
            My_current_enemy = my_vision.current_enemy;
    }
}
