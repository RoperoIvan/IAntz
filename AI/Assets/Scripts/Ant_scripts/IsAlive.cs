using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlive : MonoBehaviour
{
    public bool is_alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HealthManager>().current_health > 0)
            is_alive = true;
        else
            is_alive = false;
    }
}
