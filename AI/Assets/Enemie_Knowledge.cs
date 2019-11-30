using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_Knowledge : MonoBehaviour
{
    //Vars:
    //GameObjects:
    public GameObject Queen;
    public GameObject My_current_enemy;
    

    AIVision my_vision;

    // Start is called before the first frame update
    
    void Start()
    {
        my_vision = this.GetComponent<AIVision>();
    }

    // Update is called once per frame
    void Update()
    {
        My_current_enemy = null;
        My_current_enemy = my_vision.current_enemy;
    }
}
