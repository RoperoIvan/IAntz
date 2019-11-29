using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringSeek : SteeringAbstract {

	Move move;
    NavMeshPath path;
    Vector3 complete_path_target;
    Vector3 path_target;
    int actual_corner;


    // Use this for initialization
    void Start ()
    {
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
        if (move.target.transform.position != complete_path_target) // If we have a new target to we want to recalculate the path.
        {
            complete_path_target = move.target.transform.position; // We define which is the new current target.
            actual_corner = 0; // We reset the corners of the path.
            // We calculate the new path
            if (NavMesh.CalculatePath(this.transform.position, move.target.transform.position, NavMesh.GetAreaFromName("walkable"), path))
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
            to_do = move.target.transform.position;
        }
        else
        {
            to_do = path_target;
        }

        Steer(to_do, priority);
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
