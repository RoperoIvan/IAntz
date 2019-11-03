using UnityEngine;
using System.Collections;

public class SteeringWander : SteeringAbstract
{

	public float min_distance = 5f;
    public float strength = 5f;
    Move move;
    SteeringAlign align;
    // Use this for initialization
    float random_angle = Random.Range(-359, 359);

    void Start()
    {
        move = GetComponent<Move>();
        align = GetComponent<SteeringAlign>();        
    }

    void Update()
    {
        Vector3 vec_vel = move.current_velocity;
        vec_vel.Normalize();
        vec_vel *= min_distance;
        Vector3 vec_change_trajectory = new Vector3(0, -1);
        vec_change_trajectory *= strength;
        random_angle = Random.Range(-359, 359);
        vec_change_trajectory.x = Mathf.Cos(random_angle) * vec_change_trajectory.magnitude;
        vec_change_trajectory.y = Mathf.Sin(random_angle) * vec_change_trajectory.magnitude;     
        Vector3 vec_wander_result = vec_vel + vec_change_trajectory;
        align.DrivetoTarget(vec_wander_result, priority);
    }
    
    void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
