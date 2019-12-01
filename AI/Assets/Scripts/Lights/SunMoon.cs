using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public Light sunlight;
    public int cicle_strength = 12;
    private void Start()
    {
    }
    private void Update()
    {
        sunlight.transform.RotateAround(Vector3.zero, Vector3.right, cicle_strength * Time.deltaTime);
        sunlight.transform.LookAt(Vector3.zero);      
    }
}