using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringAlign : SteeringAbstract
{

	public float min_angle = 1f;
	public float slow_angle = 10.0f;
	public float time_to_target = 0.1f;
    public float slow_factor;
    public float desired_rotation;
    public Vector3 vec_my_front;
    public Vector3 vec_t_m;

    Vector3 complete_path_target;
    Vector3 path_target;
    int actual_corner;
    Move move;
    NavMeshPath path;
    // Use this for initialization
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
        if (desired_rotation <= min_angle && desired_rotation >= -min_angle)
            move.SetRotationVelocity(0, priority);
    }

    public void DrivetoTarget(Vector3 target, int prio)
    {
        if (target != complete_path_target) // If we have a new target to we want to recalculate the path.
        {
            //Debug.Log("New Path Adquired");
            complete_path_target = target; // We define which is the new current target.
            actual_corner = 0; // We reset the corners of the path.
            // We calculate the new path
            if (NavMesh.CalculatePath(this.transform.position, complete_path_target, NavMesh.GetAreaFromName("walkable"), path))
            {
                //We assign our current path target to the first corner of the new path.
                //Debug.Log("Path correctly calculated");
                path_target = path.corners[actual_corner];
            }
            else
            {
                //Debug.Log("Path was not calculated");
                path_target = Vector3.zero;
            }

        }
        float helper;
        Vector3 helper_vec;

        // We wanna know the distance between our position and our path_target.
        helper_vec = path_target - this.transform.position;

        helper = helper_vec.magnitude;

        // If the distance is below 0,5 We go to the next corner.
        if (helper <= 0.3f && actual_corner < path.corners.Length - 1)
        {
            //Debug.Log("New Corner Adquired");
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


        float current_rotation;
        float correct_rotation;

        current_rotation = move.current_rotation_speed;

        vec_t_m = to_do - this.transform.position;
        vec_my_front = this.transform.forward;

        desired_rotation = Vector3.SignedAngle(vec_my_front, vec_t_m, Vector3.up);

        if (desired_rotation <= min_angle && desired_rotation >= -min_angle)
            move.SetRotationVelocity(0, prio);
        else
        {
            correct_rotation = (desired_rotation);
           // Debug.Log("im_enetering_here " + this.gameObject);
            correct_rotation = Mathf.Clamp(correct_rotation, -move.max_rot_acceleration, move.max_rot_acceleration);

            move.AccelerateRotation(correct_rotation, prio);
            //move.AccelerateMovement(this.transform.forward, prio);

        }
        vec_t_m.Normalize();
        vec_t_m *= move.max_mov_acceleration;
        move.AccelerateMovement(vec_t_m, prio);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, path_target);
    }
}
