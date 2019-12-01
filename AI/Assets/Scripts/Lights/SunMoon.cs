using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public Transform sun_tr;
    public int rotation_scale;
    public Light sun;
    private void Start()
    {
        rotation_scale = 12;
    }
    private void Update()
    {
        sun_tr.Rotate(rotation_scale * Time.deltaTime, 0, 0);
    }
}