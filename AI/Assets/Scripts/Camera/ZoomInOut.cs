using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public float minimum_fov = 15f;
    public float maximum_fov = 90f;
    public float zoom_speed = 30f;
    void Update()
    {
      float fov = Camera.main.fieldOfView;
      fov -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed * Time.deltaTime;
      fov = Mathf.Clamp(fov, minimum_fov, maximum_fov);
      Camera.main.fieldOfView = fov;
    }
}

