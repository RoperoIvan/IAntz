﻿using UnityEngine;
using System.Collections;

public class SteeringArrive : SteeringAbstract
{

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_accel = 0.2f;
    public float slow_factor;
    Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		    Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Find the acceleration to achieve the desired velocity
        // If we are close enough to the target just stop moving and do nothing else
        // Calculate the desired acceleration using the velocity we want to achieve and the one we already have
        // Use time_to_target as the time to transition from the current velocity to the desired velocity
        // Clamp the desired acceleration and call move.AccelerateMovement()
        //vector tarjet me;
        Vector3 vec_t_m;
        Vector3 vec_act;
        Vector3 vec_crt;
        Vector3 vec_fn;

   

        vec_act = move.current_velocity;
        vec_t_m = target - this.transform.position;


        if (vec_t_m.magnitude <= min_distance)
            move.SetMovementVelocity(Vector3.zero, priority);
        else
        {
            if (vec_t_m.magnitude <= slow_distance)
                slow_factor = (vec_t_m.magnitude / slow_distance);
            else
                slow_factor = 1;
              
            vec_t_m.Normalize();
            vec_t_m *= move.max_mov_speed * slow_factor;

            vec_crt = ((vec_t_m - vec_act)/time_to_accel);

            vec_fn = vec_crt.normalized;
            float clamped = Mathf.Clamp(vec_crt.magnitude, -move.max_mov_acceleration, move.max_mov_acceleration);
            vec_fn *= clamped;

            move.AccelerateMovement(vec_fn, priority);
          
            
        }


        //TODO 4: Add a slow factor to reach the target
        // Start slowing down when we get closer to the target
        // Calculate a slow factor (0 to 1 multiplier to desired velocity)
        // Once inside the slow radius, the further we are from it, the slower we go

    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}