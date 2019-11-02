using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SteeringAlign : SteeringAbstract
{

	public float min_angle = 0.01f;
	public float slow_angle = 10.0f;
	public float time_to_target = 0.1f;
    public float slow_factor;



    Move move;
    NavMeshPath path;
    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
         path = new NavMeshPath();
    }

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions
        //DrivetoTarget(move.target.transform.position, priority);

    }
    public void DrivetoTarget(Vector3 target, int prio)
    {
        float current_rotation;
        float desired_rotation;
        float correct_rotation;
        Vector3 to_do;

        if (NavMesh.CalculatePath(this.transform.position, target, NavMesh.GetAreaFromName("walkable"), path))
            to_do = path.corners[1];
        else
            to_do = target;

        Vector3 vec_t_m;
        Vector3 vec_my_front;


        current_rotation = move.current_rotation_speed;

        vec_t_m = to_do - this.transform.position;
        vec_my_front = this.transform.forward;

        desired_rotation = Vector3.SignedAngle(vec_my_front, vec_t_m, Vector3.up);

        if (desired_rotation <= min_angle && desired_rotation >= -min_angle)
            move.SetRotationVelocity(0, prio);
        else
        {
            //if (desired_rotation <= slow_angle && desired_rotation >= -slow_angle)
            //    slow_factor = desired_rotation / slow_angle;
            //else
            //    slow_factor = 1;
            //desired_rotation *= slow_factor;

            correct_rotation = (desired_rotation - current_rotation) / time_to_target;

            correct_rotation = Mathf.Clamp(correct_rotation, -move.max_rot_acceleration, move.max_rot_acceleration);

            move.AccelerateRotation(correct_rotation, prio);
            move.AccelerateMovement(this.transform.forward, prio);


        }
    }
}
