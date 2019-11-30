using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int current_health;
    MoodManager Mmanager;
    public bool is_alive = true;
    // Start is called before the first frame update
    void Start()
    {
        Mmanager = this.GetComponent<MoodManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health == health)
        {
            Mmanager.current_mood = 0;
            is_alive = false;
        }

        if (current_health == health / 2)
            Mmanager.current_mood = 1;

    }
}
