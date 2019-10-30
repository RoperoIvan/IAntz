using UnityEngine;
using System.Collections;

public class SteeringVelocityMatching : MonoBehaviour {

	public float time_to_accel = 0.25f;

	Move move;
	Move target_move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		target_move = move.target.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target_move)
		{
            // TODO 8: First come up with your ideal velocity
            // then accelerate to it.
            Vector3 vec_desired = target_move.movement_vel;
            Vector3 vec_my_vel = move.movement_vel;
            Vector3 final_acc;

            Vector3 accelerate_to_match = (vec_desired - vec_my_vel) / time_to_accel;
            final_acc = accelerate_to_match.normalized;

            float Clamped = Mathf.Clamp(accelerate_to_match.magnitude, -move.max_mov_acceleration, move.max_mov_acceleration);

            final_acc *= Clamped;

            move.AccelerateMovement(final_acc);


            
        }
	}
}
