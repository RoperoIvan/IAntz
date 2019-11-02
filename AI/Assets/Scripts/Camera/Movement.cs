using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float cam_speed = 20f;
    public float cam_rot_speed = 5f;
    public Vector2 bounds = new Vector2(100,100);
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

        if (Input.GetKey("w") && transform.position.z < bounds.y)
        {
            this.transform.Translate(0, trans, 0);
        }
        if (Input.GetKey("a") && transform.position.x > -bounds.x)
        {
            this.transform.Translate(-trans, 0, 0);
        }
        if (Input.GetKey("s") && transform.position.z > -bounds.y)
        {
            this.transform.Translate(0, -trans, 0);
        }
        if (Input.GetKey("d") && transform.position.x < bounds.x)
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
