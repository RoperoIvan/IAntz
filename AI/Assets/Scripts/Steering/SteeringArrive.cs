using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class SteeringArrive : SteeringAbstract
{

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_accel = 0.2f;
    public float slow_factor;
    Move move;
    NavMeshPath path;
    // Use this for initialization


    Vector3 complete_path_target;
    Vector3 path_target;
    int actual_corner;

    void Start () { 
		move = GetComponent<Move>();
        path = new NavMeshPath();
        //our next point in the path.
        path_target = Vector3.zero;
        //the current destination of the current path.
        complete_path_target = Vector3.zero;
        //our current corner in the path.
        actual_corner = 0;
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

        Vector3 vec_t_m;
        Vector3 vec_act;
        Vector3 vec_crt;
        Vector3 vec_fn;

        if (target != complete_path_target) // If we have a new target to we want to recalculate the path.
        {
            complete_path_target = target; // We define which is the new current target.
            actual_corner = 0; // We reset the corners of the path.
            // We calculate the new path
            if (NavMesh.CalculatePath(this.transform.position, target, NavMesh.GetAreaFromName("walkable"), path))
            {
                //We assign our current path target to the first corner of the new path.
                path_target = path.corners[actual_corner];
            }
            else
            {
                path_target = Vector3.zero;
            }

        }
        float helper;
        Vector3 helper_vec;

        // We wanna know the distance between our position and our path_target.
        helper_vec = path_target - this.transform.position;

        helper = helper_vec.magnitude;

        // If the distance is below 0,5 We go to the next corner.
        if (helper <= 0.1f && actual_corner < path.corners.Length)
        {
            actual_corner++;
            path_target = path.corners[actual_corner];
        }

        Vector3 to_do = Vector3.zero;
        if (path_target == Vector3.zero)
        {
            to_do = target;
        }
        else
        {
            to_do = path_target;
        }


        vec_act = move.current_velocity;
        vec_t_m = to_do - this.transform.position;


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
