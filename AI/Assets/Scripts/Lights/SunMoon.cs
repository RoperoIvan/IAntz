using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public Light sunlight;
    public float cicle_strength = 0.1f;
    private void Start()
    {
    }
    private void Update()
    {
        if(!GameObject.Find("Anthill Resources").GetComponent<DayManager>().next_day)
            sunlight.transform.RotateAround(Vector3.zero, Vector3.right, cicle_strength * Time.deltaTime);

        sunlight.transform.LookAt(Vector3.zero);      
    }
}