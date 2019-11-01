using UnityEngine;
using System.Collections;

public class SteeringSeek : SteeringAbstract {

	Move move;

	// Use this for initialization
	void Start ()
    {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Steer(move.target.transform.position, priority);
	}

	public void Steer(Vector3 target, int prio)
	{
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()
        
        Vector3 movement_accelerated;
        Vector3 vec_t_m;

        vec_t_m = target - this.transform.position;

        vec_t_m.Normalize();

        movement_accelerated = vec_t_m * move.max_mov_acceleration;

        move.AccelerateMovement(movement_accelerated, prio);
        

    }
}
