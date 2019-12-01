using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PheromonesSecrete : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(GetComponent<AIVision>().current_enemy != null)
            enemy = GetComponent<Warrior_knowledge>().My_current_enemy;
    }
}
