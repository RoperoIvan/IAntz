using UnityEngine;
using System.Collections;

public class SteeringWander : SteeringAbstract
{

	public float min_distance = 5f;

	Move move;
    SteeringAlign align;
    Vector3 vec_random_destination;
    // Use this for initialization
    float random_angle;

    void Start()
    {
        move = GetComponent<Move>();
        align = GetComponent<SteeringAlign>();        
        random_angle = Random.Range(0, 359);
    }

    void Update()
    {
        Vector3 vec_circle = move.current_velocity;
        vec_circle.Normalize();
        vec_circle *= min_distance;
        Vector3 vec_displacement = new Vector3(0, -1);
        vec_displacement *= 10;
        vec_displacement.x = Mathf.Cos(random_angle) * vec_displacement.magnitude;
        vec_displacement.y = Mathf.Sin(random_angle) * vec_displacement.magnitude;

        random_angle = Random.Range(0, 359);
        Vector3 vec_wander_force = vec_circle + vec_displacement;
        align.DrivetoTarget(vec_wander_force, priority);
    }
    
    void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
