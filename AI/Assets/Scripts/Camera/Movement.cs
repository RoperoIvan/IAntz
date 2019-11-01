using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float cam_speed = 20f;
    public float cam_rot_speed = 5f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TranslateCamera();
        RotateCamera();

    }
    void TranslateCamera()
    {
        float trans = cam_speed * Time.deltaTime;

        if (Input.GetKey("w"))
        {
            this.transform.Translate(0, trans, 0);
        }
        if (Input.GetKey("a"))
        {
            this.transform.Translate(-trans, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            this.transform.Translate(0, -trans, 0);
        }
        if (Input.GetKey("d"))
        {
            this.transform.Translate(trans, 0, 0);
        }
    }
    void RotateCamera()
    {
        if(Input.GetKey("q"))
        {
            this.transform.Rotate(Vector3.up, cam_rot_speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e"))
        {
            this.transform.Rotate(Vector3.down, cam_rot_speed * Time.deltaTime, Space.World);
        }
    }
}
