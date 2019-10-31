using UnityEngine;
using System.Collections;
[System.Serializable]
public class CustomRayCast
{
    public Vector3 vec_direction = Vector3.forward;
    public float length = 4.0f;
}

public class SteeringObstacleAvoidance : MonoBehaviour {

	public LayerMask mask;
	public float avoid_distance = 5.0f;
    public CustomRayCast[] ray;

	Move move;
	SteeringSeek seek;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>(); 
		seek = GetComponent<SteeringSeek>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 2: Agents must avoid any collider in their way
        // 1- Create your own (serializable) class for rays and make a public array with it
        // 2- Calculate a quaternion with rotation based on movement vector
        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        // 4- Make sure there is debug draw for all rays (below in OnDrawGizmosSelected)

        foreach (CustomRayCast custom_ray in ray)
        {
            RaycastHit hit;
            Vector3 vec_detect_pos = new Vector3(transform.position.x, 1.0f, transform.position.z);
            if (Physics.Raycast(vec_detect_pos, custom_ray.vec_direction, out hit, custom_ray.length, mask) == true)
            {
                Vector3 vec_escape = new Vector3(hit.point.x, transform.position.y, hit.point.z) + hit.normal * avoid_distance;
                seek.Steer(vec_escape);

            }
        }
    }

	void OnDrawGizmosSelected() 
	{
		if(move && this.isActiveAndEnabled)
		{
			Gizmos.color = Color.red;
			float angle = Mathf.Atan2(move.movement_vel.x, move.movement_vel.z);
			Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

            // TODO 2: Debug draw thoise rays (Look at Gizmos.DrawLine)
            foreach (CustomRayCast custom_ray in ray)
                Gizmos.DrawLine(transform.position, transform.position + (q * custom_ray.vec_direction.normalized) * custom_ray.length);
        }
	}
}
