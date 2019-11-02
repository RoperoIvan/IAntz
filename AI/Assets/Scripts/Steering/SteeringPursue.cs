using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringPursue : SteeringAbstract
{

	public float max_seconds_prediction;
    public GameObject target;
    
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
        Steer();
	}

	public void Steer()
	{
        // TODO 5: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time

        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have

        Vector3 vec_direction = target.transform.position - this.transform.position; //Direction between the character and the target
        float distance_from_target = vec_direction.magnitude;
        float current_speed = move.current_velocity.magnitude;
        float time_until_we_collide = distance_from_target / current_speed; // We want to arrive as fast as needed based in the time we put

        if (time_until_we_collide > max_seconds_prediction)
            time_until_we_collide = max_seconds_prediction;

        vec_direction = (target.transform.position + target.GetComponent<Move>().current_velocity * time_until_we_collide) - transform.position;
        distance_from_target = vec_direction.magnitude;
        current_speed = move.current_velocity.magnitude;
        time_until_we_collide = distance_from_target / current_speed; // We want to arrive as fast as needed based in the time we put

        if (time_until_we_collide > max_seconds_prediction)
            time_until_we_collide = max_seconds_prediction;

        //if (current_speed > speed_desired) // If the speed of the character is higher than what we want we cap our future speed;
        //    future_speed = distance_from_target / current_speed;
        //else //If not we will go fullspeed
        //    future_speed = max_seconds_prediction;


        Vector3 vec_prediction = target.transform.position + target.GetComponent<Move>().current_velocity * time_until_we_collide; //Then we add our future speed to the target one
        align.DrivetoTarget(vec_prediction, priority);
    }
}
