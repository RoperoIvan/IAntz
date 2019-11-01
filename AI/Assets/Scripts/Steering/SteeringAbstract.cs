using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SteeringAbstract : MonoBehaviour
{
    
    [Range(0, SteeringConf.num_priorities)]
    public int priority = 0;
}

