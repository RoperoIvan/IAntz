﻿using UnityEngine;
using System.Collections;
[System.Serializable]
public class CustomRayCast
{
    public Vector3 vec_direction = Vector3.forward;
    public float length = 4.0f;
}

public class SteeringObstacleAvoidance : SteeringAbstract
{

	public LayerMask mask;
	public float avoid_distance = 10.0f;
    public CustomRayCast[] ray;
    public Vector3 Normal;
    public float current_x;
    public float current_y;
    Move move;
	SteeringSeek seek;
    SteeringAlign align;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>(); 
		seek = GetComponent<SteeringSeek>();
        align = GetComponent<SteeringAlign>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 2: Agents must avoid any collider in their way
        // 1- Create your own (serializable) class for rays and make a public array with it
        // 2- Calculate a quaternion with rotation based on movement vector
        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        // 4- Make sure there is debug draw for all rays (below in OnDrawGizmosSelected)
 
        float angle = Mathf.Atan2(move.current_velocity.x, move.current_velocity.z);
        Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);
        current_x = move.current_velocity.x;

        current_y = move.current_velocity.z;
        foreach (CustomRayCast custom_ray in ray)
        {
            RaycastHit hit;
            custom_ray.vec_direction = q * this.transform.forward;

            if (Physics.Raycast(transform.position, custom_ray.vec_direction, out hit, custom_ray.length, mask) == true)
            {
                Vector3 vec_escape = (hit.point + (hit.normal*avoid_distance));
                vec_escape.y = 0;
                
                align.DrivetoTarget(vec_escape, priority); //todo guillem
            }
            
        }
    }
    
    void OnDrawGizmosSelected() 
	{
		if(move && this.isActiveAndEnabled)
		{
			Gizmos.color = Color.red;
			float angle = Mathf.Atan2(move.current_velocity.x, move.current_velocity.z);
			Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

            // TODO 2: Debug draw thoise rays (Look at Gizmos.DrawLine)
            foreach (CustomRayCast custom_ray in ray)
                Gizmos.DrawLine(transform.position, transform.position + (custom_ray.vec_direction * custom_ray.length));
        }
	}
}
