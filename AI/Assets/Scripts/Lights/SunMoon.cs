using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public Light sunlight;
    public float cicle_strength = 0.1f;
    public GameObject resources;
    private void Start()
    {
        Vector3 day_pos = new Vector3(0f, 128.2342f, -295.3641f);
        sunlight.transform.position = day_pos;
    }
    private void Update()
    {
        if(!resources.GetComponent<DayManager>().next_day)
            sunlight.transform.RotateAround(Vector3.zero, Vector3.right, cicle_strength * Time.deltaTime);

        sunlight.transform.LookAt(Vector3.zero);      
    }
}